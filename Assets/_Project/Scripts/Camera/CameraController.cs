using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    private CinemachineVirtualCamera _cinemachineCamera;
    private CinemachinePOV _povComponent;

    private PauseMenuController _pauseController;
    private UI_GameOptions _gameOptions;

    private void Awake()
    {
        _cinemachineCamera = GetComponent<CinemachineVirtualCamera>();
        _povComponent = _cinemachineCamera.GetCinemachineComponent<CinemachinePOV>();
    }

    private void Start()
    {
        _pauseController = FindObjectOfType<PauseMenuController>();
        _pauseController.OnPause += OnGamePaused;
        _gameOptions = FindObjectOfType<UI_GameOptions>();
        _gameOptions.OnSensitivityChanged += UpdateHorizontalAndVerticalSensitivity;

        _povComponent.m_VerticalAxis.m_MaxSpeed = PlayerPrefs.GetFloat("MouseSensitivity", 4f);
        _povComponent.m_HorizontalAxis.m_MaxSpeed = PlayerPrefs.GetFloat("MouseSensitivity", 4f);

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

    public void UpdateHorizontalAndVerticalSensitivity(float sensitivity)
    {
        _povComponent.m_VerticalAxis.m_MaxSpeed = sensitivity;
        _povComponent.m_HorizontalAxis.m_MaxSpeed = sensitivity;
    }
}
