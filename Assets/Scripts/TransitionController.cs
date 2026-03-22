using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class TransitionController : MonoBehaviour
{
    [Header("Fade Settings")]
    public CanvasGroup fadeCanvasGroup;
    public float fadeDuration = 1.0f;

    // FADE BY NAME
    private IEnumerator FadeAndLoadByName(string sceneName)
    {
        yield return StartCoroutine(PerformFade());
        SceneManager.LoadScene(sceneName);
    }

    // FADE BY INDEX (For LoadNextScene)
    private IEnumerator FadeAndLoadByIndex(int sceneIndex)
    {
        yield return StartCoroutine(PerformFade());
        SceneManager.LoadScene(sceneIndex);
    }

    // This is a helper function so we don't have to write the while-loop twice
    private IEnumerator PerformFade()
    {
        if (fadeCanvasGroup == null)
        {
            Debug.LogError("Assign the Fader to the Fade Canvas Group slot!");
            yield break;
        }

        fadeCanvasGroup.blocksRaycasts = true;
        float timer = 0;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            fadeCanvasGroup.alpha = timer / fadeDuration;
            yield return null;
        }
    }

    private void Start()
    {
        // If we have a fader assigned, start the scene by fading it out
        if (fadeCanvasGroup != null)
        {
            // Set it to fully black immediately so we don't see a "glimpse" of the scene
            fadeCanvasGroup.alpha = 1;
            fadeCanvasGroup.blocksRaycasts = true;

            // Start the fade-in process
            StartCoroutine(FadeIn());
        }
    }

    private IEnumerator FadeIn()
    {
        float timer = fadeDuration; // Start at the max time

        while (timer > 0)
        {
            timer -= Time.deltaTime;
            fadeCanvasGroup.alpha = timer / fadeDuration;
            yield return null;
        }

        fadeCanvasGroup.alpha = 0;
        fadeCanvasGroup.blocksRaycasts = false; // Allow clicking again
    }

    public void StartGame()
    {
        StartCoroutine(FadeAndLoadByName("Prelude1"));
    }

    public void ExitGame()
    {
        Application.Quit();

    }

    public void Tutorial()
    {
        // Open tutorial
    }

    public void Credits()
    {
        StartCoroutine(FadeAndLoadByName("Credits"));
    }

    public void LoadNextScene()
    {
        int nextIndex = SceneManager.GetActiveScene().buildIndex + 1;

        // Check if there actually IS a next scene in the Build Settings
        if (nextIndex < SceneManager.sceneCountInBuildSettings)
        {
            StartCoroutine(FadeAndLoadByIndex(nextIndex));
        }
    }

    public void TryAgain()
    {
        StartCoroutine(FadeAndLoadByName("AdditiveMAIN"));
    }

    public void ExitToMain() 
    {
        // Takes user back to main menu
        StartCoroutine(FadeAndLoadByName("MainMenu"));
    }

}

