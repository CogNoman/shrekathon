using UnityEngine;
using UnityEngine.SceneManagement;


public class TransitionController : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Prelude1");
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
        // Open credits
    }

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void TryAgain()
    {
        SceneManager.LoadScene("AdditiveMAIN");
    }

    public void GameOverExit() 
    {
        // Takes user back to main menu where
        SceneManager.LoadScene("MainMenu");
    }

}

