using UnityEngine;

public class DoorAnimation : MonoBehaviour
{
    private Animator _animator;
    private Door _door;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _door = GetComponent<Door>();
    }

    private void Start()
    {
        _door.OnInteract += OpenCloseDoor;
    }

    public void OpenCloseDoor(bool isOpen)
    {
        _animator.SetBool("isOpen", isOpen);
    }

}
