using UnityEngine;

public class DrawerAnimation : MonoBehaviour
{
    private Animator _animator;
    private Drawer _drawer;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _drawer = GetComponent<Drawer>();
    }

    private void Start()
    {
        _drawer.OnInteract += OpenCloseDrawer;
    }

    public void OpenCloseDrawer(bool isOpen)
    {
        _animator.SetBool("isOpen", isOpen);
    }
}
