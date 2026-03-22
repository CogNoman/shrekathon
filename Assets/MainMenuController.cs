using UnityEngine;
using UnityEngine.SceneManagement;


public class TransitionControl : MonoBehaviour
{
    public void StartGame() 
    {
        // Insert start game logic
        SceneManager.LoadScene("Prelude");
    }

    public void ExitGame()
    {
        // Exit game logic
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
}
