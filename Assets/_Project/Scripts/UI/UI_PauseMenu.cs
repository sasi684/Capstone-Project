using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenuPanel;
    [SerializeField] private GameObject _gameOptionsPanel;

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
            HidePauseMenu();
            HideGameOptions();
        }
        else
        {
            ShowPauseMenu();
        }
    }

    public void ShowPauseMenu()
    {
        _pauseMenuPanel.SetActive(true);

        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        _pauseController.IsPaused = true;
    }

    public void HidePauseMenu()
    {
        _pauseMenuPanel.SetActive(false);

        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        _pauseController.IsPaused = false;
    }

    private void HideGameOptions()
    {
        _gameOptionsPanel.SetActive(false);
    }

    public void OnClickExitGame()
    {
        Application.Quit();
    }

    public void OnClickBackToMenu()
    {
        HidePauseMenu();

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        ScreenFader.Instance.StartFadeToOpaque("MainMenu");
    }

    public void OnClickGameOptions()
    {
        _gameOptionsPanel.SetActive(true);
    }
}
