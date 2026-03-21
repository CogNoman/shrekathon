using UnityEngine;
using UnityEngine.SceneManagement;

public class AdditiveSceneLoader : MonoBehaviour
{
    void Start()
    {
        LoadScenes();
    }

    void LoadScenes()
    {
        SceneManager.LoadScene("AdditiveRight", LoadSceneMode.Additive);
        SceneManager.LoadScene("playerScene", LoadSceneMode.Additive);
    }
}