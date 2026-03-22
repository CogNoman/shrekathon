using UnityEngine;

public class mapScript : MonoBehaviour
{
    public float scrollSpeed = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = new Vector2(-3.13f, 19.8f);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > -19.6)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - scrollSpeed * Time.deltaTime);
        }
    }
}
