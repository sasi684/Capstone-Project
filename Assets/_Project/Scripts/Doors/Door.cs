using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour, IInteractable
{
    [Tooltip("If true, the door cannot be open.")]
    [SerializeField] private bool _isLocked;
    [Tooltip("If toggled, interacting with this door completes the level.")]
    [SerializeField] private bool _isFinalDoor;
    [Tooltip("The Door Scriptable Object used to determine wich key opens the door if locked.")]
    [SerializeField] private SO_Door _door;

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
        else
        {
            if (GameState.Instance.UnlockDoor(_door))
            {
                _isLocked = false;
                _isOpen = true;
                OnInteract?.Invoke(true);
            }
        }

        if (_isFinalDoor && !_isLocked)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            ScreenFader.Instance.StartFadeToOpaque(ChangeSceneToEscaped);
        }
    }

    private void ChangeSceneToEscaped()
    {
        SceneManager.LoadScene("Escaped");
        ScreenFader.Instance.StartFadeToTransparent();
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
