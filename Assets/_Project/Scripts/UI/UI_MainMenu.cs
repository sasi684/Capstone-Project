using UnityEngine;

public class UI_MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _gameOptionsPanel;

    public void OnClickPlayGame()
    {
        ScreenFader.Instance.StartFadeToOpaque("DEMO");
    }

    public void OnClickLoadGame()
    {
        // TODO: aggiungere logica per caricare lo state dell'ultima partita
        ScreenFader.Instance.StartFadeToOpaque("DEMO");
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
