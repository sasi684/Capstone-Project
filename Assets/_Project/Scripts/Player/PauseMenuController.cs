using System;
using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    public event Action<bool> OnPause;

    private bool _isPaused;
    public bool IsPaused { get { return _isPaused; } set { _isPaused = value; } }

    private void Update()
    {
        PauseMenuControl();
    }

    private void PauseMenuControl()
    {
        if (PlayerInput.Instance.IsPausing)
        {
            OnPause?.Invoke(_isPaused);
        }
    }
}
