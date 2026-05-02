using System;
using UnityEngine;

public class Closet : MonoBehaviour, IInteractable
{
    public event Action<bool> OnInteract;
    private bool _isOpen;

    public void Interact()
    {
        if (_isOpen)
            CloseCloset();
        else
            OpenCloset();
    }

    private void OpenCloset()
    {
        _isOpen = true;
        AudioManager.Instance.PlaySFX("ClosetOpen");
        OnInteract?.Invoke(_isOpen);
    }

    private void CloseCloset()
    {
        _isOpen = false;
        AudioManager.Instance.PlaySFX("ClosetClose");
        OnInteract?.Invoke(_isOpen);
    }

}
