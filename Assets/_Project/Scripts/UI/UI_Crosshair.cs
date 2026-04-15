using UnityEngine;

public class UI_Crosshair : MonoBehaviour
{
    [Tooltip("The crosshair game object used for interactions")]
    [SerializeField] private GameObject _interactCrosshair;

    private PlayerController _playerController;

    private void Start()
    {
        _playerController = FindObjectOfType<PlayerController>();
        _playerController.OnLookInteractable += ShowHideInteractCrosshair;
    }

    private void ShowHideInteractCrosshair(bool isInteracting)
    {
        _interactCrosshair.SetActive(isInteracting);
    }
}
