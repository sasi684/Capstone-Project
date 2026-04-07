using System;
using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    private PlayerInput _input;

    public event Action<bool> OnPause;

    private bool _isPaused;
    public bool IsPaused { get { return _isPaused; } set { _isPaused = value; } }

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        PauseMenuControl();
    }

    private void PauseMenuControl()
    {
        if (_input.IsPausing)
        {
            OnPause?.Invoke(_isPaused);
        }
    }
}
