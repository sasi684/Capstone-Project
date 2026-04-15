using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_MainMenu : MonoBehaviour
{
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
        // TODO: creare pannello delle opzioni e aprirlo/chiuderlo
    }

    public void OnClickExitGame()
    {
        Application.Quit();
    }

}
