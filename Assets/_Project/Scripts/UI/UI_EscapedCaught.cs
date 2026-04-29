using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_EscapedCaught : MonoBehaviour
{
    
    public void OnClickMainMenu()
    {
        ScreenFader.Instance.StartFadeToOpaque(ChangeSceneToMainMenu);
    }

    public void OnClickExitGame()
    {
        Application.Quit();
    }

    private void ChangeSceneToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        ScreenFader.Instance.StartFadeToTransparent();
    }
}
