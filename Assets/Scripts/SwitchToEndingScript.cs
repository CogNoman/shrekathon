using System;
using UnityEngine;

public class SwitchToEndingScript : MonoBehaviour
{

    private float gameTime = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameTime += Time.deltaTime;
        if (gameTime >= 60f)
        {
            // Load the ending scene
            if (InventoryManager.Instance.collectedItems.Count < 24)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("BadEnd_p1");
            }
            else
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("GoodEnd_p1");
            }
        }
    }
}
