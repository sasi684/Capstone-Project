using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_EscapedCaught : MonoBehaviour
{
    
    public void OnClickMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnClickExitGame()
    {
        Application.Quit();
    }

}
