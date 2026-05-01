using System;
using System.Collections;
using UnityEngine;

public class ScreenFader : GenericSingleton<ScreenFader>
{

    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private float _fadeTime = 5f;

    public void StartFadeToOpaque(string nextScene = null)
    {
        PlayerInput.Instance.DisablePlayerInput();

        StopAllCoroutines();
        gameObject.SetActive(true);
        StartCoroutine(FadeCoroutine(0f, 1f, _fadeTime, nextScene));
    }

    public void StartFadeToTransparent(string nextScene = null)
    {
        PlayerInput.Instance.EnablePlayerInput();

        StopAllCoroutines();
        gameObject.SetActive(true);
        StartCoroutine(FadeCoroutine(1f, 0f, _fadeTime, nextScene));
    }

    private IEnumerator FadeCoroutine(float startValue, float endValue, float duration, string nextScene)
    {
        _canvasGroup.alpha = startValue;
        float timer = 0f;
        while (timer < duration)
        {
            yield return null;

            timer += Time.deltaTime;
            _canvasGroup.alpha = Mathf.Lerp(startValue, endValue, timer / duration);
        }
        _canvasGroup.alpha = endValue;

        if (endValue <= Mathf.Epsilon)
        {
            gameObject.SetActive(false);
        }
        else
        {
            SceneLoader.Instance.LoadScene(nextScene);
        }
    }
}
