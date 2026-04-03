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

    private PlayerInput _input;
    private CharacterController _controller;

    private Vector3 _moveDirection;
    private float _verticalVelocity;

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Movement();
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
            _moveDirection = new Vector3(_input.HorizontalMovement, 0f, _input.VerticalMovement).normalized * _sprintSpeedMultiplier;
        else
            _moveDirection = new Vector3(_input.HorizontalMovement, 0f, _input.VerticalMovement).normalized;
    }
}
