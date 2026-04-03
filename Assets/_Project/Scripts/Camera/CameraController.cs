using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    private CinemachineVirtualCamera _cinemachineCamera;
    private CinemachinePOV _povComponent;

    private void Awake()
    {
        _cinemachineCamera = GetComponent<CinemachineVirtualCamera>();
        _povComponent = _cinemachineCamera.GetCinemachineComponent<CinemachinePOV>();
    }

    private void Start()
    {
        _povComponent.m_VerticalAxis.m_MaxSpeed = PlayerPrefs.GetFloat("Vertical Sensitivity", 4f);
        _povComponent.m_HorizontalAxis.m_MaxSpeed = PlayerPrefs.GetFloat("Horizontal Sensitivity", 4f);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void UpdateHorizontalAndVerticalSensitivity()
    {
        _povComponent.m_VerticalAxis.m_MaxSpeed = PlayerPrefs.GetFloat("Vertical Sensitivity", 4f);
        _povComponent.m_HorizontalAxis.m_MaxSpeed = PlayerPrefs.GetFloat("Horizontal Sensitivity", 4f);
    }
}
