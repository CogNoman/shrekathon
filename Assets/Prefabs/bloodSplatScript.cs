using UnityEngine;

public class bloodSplatScript : MonoBehaviour
{

    public AudioClip splatSound; // drag and drop the sound to it

    public float scrollSpeed = 2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // plays splat sound when the splat appears
        AudioSource.PlayClipAtPoint(splatSound, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - scrollSpeed * Time.deltaTime);
    }

    // disappears when collides with bottom border
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("BottomBorder"))
        {
            Destroy(gameObject);
        }
    }
}
