using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _gameOptionsPanel;

    public void OnClickPlayGame()
    {
        SceneManager.LoadScene("DEMO");
    }

    public void OnClickLoadGame()
    {
        // TODO: aggiungere logica per caricare lo state dell'ultima partita
        SceneManager.LoadScene("DEMO");
    }

    public void OnClickGameOptions()
    {
        _gameOptionsPanel.SetActive(true);
    }

    public void OnClickExitGame()
    {
        Application.Quit();
    }

}
