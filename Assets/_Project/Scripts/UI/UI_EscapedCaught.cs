using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_EscapedCaught : MonoBehaviour
{
    
    public void OnClickMainMenu()
    {
        ScreenFader.Instance.StartFadeToOpaque("MainMenu");
    }

    public void OnClickExitGame()
    {
        Application.Quit();
    }
}
