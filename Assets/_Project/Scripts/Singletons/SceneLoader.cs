using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : GenericSingleton<SceneLoader>
{
    
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        ScreenFader.Instance.StartFadeToTransparent();

        AudioManager.Instance.PlayMusic(sceneName);
    }

}
