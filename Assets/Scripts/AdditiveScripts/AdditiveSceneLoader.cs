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
        SceneManager.LoadScene("AdditiveLeft", LoadSceneMode.Additive);
        SceneManager.LoadScene("AdditiveRight", LoadSceneMode.Additive);
    }
}