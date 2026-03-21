using UnityEngine;

public class ClickTest : MonoBehaviour
{
    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void OnMouseDown()
    {
        Debug.Log("Sprite clicked!");

        // Change to a random color
        sr.color = new Color(Random.value, Random.value, Random.value);
    }
}