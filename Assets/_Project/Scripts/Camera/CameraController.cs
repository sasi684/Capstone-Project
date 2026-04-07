using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    private CinemachineVirtualCamera _cinemachineCamera;
    private CinemachinePOV _povComponent;

    private PauseMenuController _pauseController;

    private void Awake()
    {
        _cinemachineCamera = GetComponent<CinemachineVirtualCamera>();
        _povComponent = _cinemachineCamera.GetCinemachineComponent<CinemachinePOV>();
    }

    private void Start()
    {
        _pauseController = FindObjectOfType<PauseMenuController>();
        _pauseController.OnPause += OnGamePaused;

        _povComponent.m_VerticalAxis.m_MaxSpeed = PlayerPrefs.GetFloat("Vertical Sensitivity", 4f);
        _povComponent.m_HorizontalAxis.m_MaxSpeed = PlayerPrefs.GetFloat("Horizontal Sensitivity", 4f);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnGamePaused(bool active)
    {
        if(_povComponent.enabled)
            _povComponent.enabled = active;
        else
            _povComponent.enabled = active;
    }

    public void UpdateHorizontalAndVerticalSensitivity(float verticalSensitivity, float horizontalSensitivity)
    {
        _povComponent.m_VerticalAxis.m_MaxSpeed = verticalSensitivity;
        _povComponent.m_HorizontalAxis.m_MaxSpeed = horizontalSensitivity;
    }
}
