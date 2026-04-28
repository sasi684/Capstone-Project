using System;
using UnityEngine;

public class Drawer : MonoBehaviour, IInteractable
{
    public event Action<bool> OnInteract;
    private bool _isOpen;

    public void Interact()
    {
        _isOpen = !_isOpen;
        OnInteract?.Invoke(_isOpen);
    }

}
