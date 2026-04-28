using UnityEngine;

public class ClosetAnimation : MonoBehaviour
{
    private Animator _animator;
    private Closet _closet;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _closet = GetComponent<Closet>();
    }

    private void Start()
    {
        _closet.OnInteract += OpenCloseCloset;
    }

    public void OpenCloseCloset(bool isOpen)
    {
        _animator.SetBool("isOpen", isOpen);
    }
}
