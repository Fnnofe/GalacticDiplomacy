using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditScroll : MonoBehaviour
{
    public RectTransform creditsText;
    public float scrollSpeed = 100f;
    public float endDelay = 5f;
    public string mainMenuSceneName = "Main menu";
    public CanvasGroup fadeCanvasGroup;
    public float fadeDuration = 5f;

    private bool finished = false;

    void Update()
    {
        if (finished) return;

        creditsText.anchoredPosition += Vector2.up * scrollSpeed * Time.deltaTime;

        if (creditsText.anchoredPosition.y >= creditsText.sizeDelta.y + 1000f)
        {
            finished = true;
            StartCoroutine(FadeOutAndLoadMainMenu());
        }
    }

    IEnumerator FadeOutAndLoadMainMenu()
    {
        yield return new WaitForSeconds(endDelay);

        // Fade to black
        float t = 0f;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            fadeCanvasGroup.alpha = Mathf.Lerp(0f, 1f, t / fadeDuration);
            yield return null;
        }

        SceneManager.LoadScene(mainMenuSceneName);
    }
}
