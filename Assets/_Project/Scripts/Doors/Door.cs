using System;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [Tooltip("If true, the door cannot be open")]
    [SerializeField] private bool _isLocked;

    public event Action<bool> OnInteract;
    private bool _isOpen;

    private MeshCollider[] _colliders;

    private void Awake()
    {
        _colliders = GetComponentsInChildren<MeshCollider>();
    }

    private void Start()
    {
        OnInteract += EnableDisableCollider;
    }

    public void Interact()
    {
        if (!_isLocked)
        {
            _isOpen = !_isOpen;
            OnInteract?.Invoke(_isOpen);
        }
    }

    private void EnableDisableCollider(bool isOpen)
    {
        foreach (var collider in _colliders)
        {
            collider.enabled = !isOpen;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (!_isLocked && !_isOpen)
            {
                _isOpen = true;
                OnInteract?.Invoke(_isOpen);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (!_isLocked && _isOpen)
            {
                _isOpen = false;
                OnInteract?.Invoke(_isOpen);
            }
        }
    }
}
