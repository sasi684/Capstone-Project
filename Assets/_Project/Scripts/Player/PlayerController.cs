using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Movement Settings")]
    [Tooltip("Determines the movement speed of the player")]
    [SerializeField] private float _moveSpeed = 5f;
    [Tooltip("Determines the multiplier applied to the speed of the player while sprinting")]
    [SerializeField] private float _sprintSpeedMultiplier = 1.5f;
    [Tooltip("Determines the gravity acceleration applied to the player")]
    [SerializeField] private float _gravity = -9.81f;
    [Tooltip("Determines the max height the player can reach jumping")]
    [SerializeField] private float _jumpHeight = 1.5f;

    [Header("Interactions Settings")]
    [Tooltip("Determines the max distance the player can reach to interact with objects")]
    [SerializeField] private float _maxInteractDistance = 3f;

    private PlayerInput _input;
    private CharacterController _controller;
    private Camera _camera;

    private Vector3 _moveDirection;
    private float _verticalVelocity;

    public event Action<bool> OnLookInteractable;

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
        _controller = GetComponent<CharacterController>();
        _camera = Camera.main;
    }

    private void Update()
    {
        Movement();
        Interaction();
    }

    private void Movement()
    {
        CalculateMovementSpeed();
        _moveDirection.y = CalculateGravity();

        _controller.Move(_moveDirection * _moveSpeed * Time.deltaTime);
    }

    private float CalculateGravity()
    {
        if (_controller.isGrounded)
        {
            _verticalVelocity = -1f;

            Jump(ref _verticalVelocity);
        }
        else
            _verticalVelocity += _gravity * Time.deltaTime;

        return _verticalVelocity;
    }

    private void Jump(ref float verticalVelocity)
    {
        if(_input.IsJumping)
            verticalVelocity = Mathf.Sqrt(_jumpHeight * _gravity * -2);
    }

    private void CalculateMovementSpeed()
    {
        if (_input.IsSprinting)
            _moveDirection = (_camera.transform.forward * _input.VerticalMovement + _camera.transform.right * _input.HorizontalMovement) * _sprintSpeedMultiplier;
        else
            _moveDirection = _camera.transform.forward * _input.VerticalMovement + _camera.transform.right * _input.HorizontalMovement;
    }

    private void Interaction()
    {
        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out RaycastHit hit, _maxInteractDistance))
        {
            if(hit.collider.TryGetComponent(out IInteractable interactable))
            {
                OnLookInteractable?.Invoke(true);
                if(_input.IsInteracting)
                    interactable.Interact();
            }
            else
            {
                OnLookInteractable?.Invoke(false);
            }
        }
        else
        {
            OnLookInteractable?.Invoke(false);
        }
    }
}
