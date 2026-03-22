using UnityEngine;
using UnityEngine.SceneManagement; // Essential for changing scenes
using System.Collections;

public class AutoSceneChanger : MonoBehaviour
{
    [SerializeField] private float delayBeforeLoading = 10.0f; // Time in seconds
    [SerializeField] private string nextSceneName; // Type the name of your next scene here

    void Start()
    {
        // Start the timer as soon as the scene loads
        StartCoroutine(WaitAndLoad());
    }

    IEnumerator WaitAndLoad()
    {
        // 1. Wait for the specified time
        yield return new WaitForSeconds(delayBeforeLoading);

        // 2. (Optional) Trigger your fade animation here if you have one
        // GetComponent<Animator>().SetTrigger("FadeOut");
        // yield return new WaitForSeconds(1.0f); // Wait for fade to finish

        // 3. Load the next scene
        SceneManager.LoadScene(nextSceneName);
    }
}
