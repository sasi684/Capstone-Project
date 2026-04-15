using System;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [Tooltip("If true, the door cannot be open")]
    [SerializeField] private bool _isLocked;

    public Action<bool> OnInteract;
    private bool _isOpen;

    public void Interact()
    {
        if (!_isLocked)
        {
            _isOpen = !_isOpen;
            OnInteract?.Invoke(_isOpen);
        }
    }
}
