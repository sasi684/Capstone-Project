using System;
using UnityEngine;

public class UI_PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenuPanel;

    private PauseMenuController _pauseController;

    private void Start()
    {
        _pauseController = FindObjectOfType<PauseMenuController>();
        _pauseController.OnPause += OnGamePaused;
    }

    private void OnGamePaused(bool isPaused)
    {
        if (isPaused)
        {
            Hide();
        }
        else
        {
            Show();
        }
    }

    public void Show()
    {
        _pauseMenuPanel.SetActive(true);

        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        _pauseController.IsPaused = true;
    }

    public void Hide()
    {
        _pauseMenuPanel.SetActive(false);

        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        _pauseController.IsPaused = false;
    }

    public void OnClickExitGame()
    {
        Application.Quit();
    }

    public void OnClickBackToMenu()
    {
        //TODO: da aggiungere logica per tornare alla scena del menù
    }

    public void OnClickGameOptions()
    {
        //TODO: da aggiungere pannello delle opzioni
    }
}
