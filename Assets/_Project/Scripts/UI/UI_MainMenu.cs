using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _gameOptionsPanel;

    public void OnClickPlayGame()
    {
        ScreenFader.Instance.StartFadeToOpaque(ChangeSceneToLevel);
    }

    public void OnClickLoadGame()
    {
        // TODO: aggiungere logica per caricare lo state dell'ultima partita
        ScreenFader.Instance.StartFadeToOpaque(ChangeSceneToLevel);
    }

    public void OnClickGameOptions()
    {
        _gameOptionsPanel.SetActive(true);
    }

    public void OnClickExitGame()
    {
        Application.Quit();
    }

    private void ChangeSceneToLevel()
    {
        SceneManager.LoadScene("DEMO");
        ScreenFader.Instance.StartFadeToTransparent();
    }

}
