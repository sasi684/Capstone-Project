using System;
using UnityEngine;

public class Drawer : MonoBehaviour, IInteractable
{
    public event Action<bool> OnInteract;
    private bool _isOpen;

    public void Interact()
    {
        if (_isOpen)
            CloseDrawer();
        else
            OpenDrawer();
    }

    private void OpenDrawer()
    {
        _isOpen = true;
        AudioManager.Instance.PlaySFX("DrawerOpen");
        OnInteract?.Invoke(_isOpen);
    }

    private void CloseDrawer()
    {
        _isOpen = false;
        AudioManager.Instance.PlaySFX("DrawerClose");
        OnInteract?.Invoke(_isOpen);
    }
}
