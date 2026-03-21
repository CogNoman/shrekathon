using UnityEngine;

public class BackgroundScaler : MonoBehaviour
{
    void Start()
    {
        // Ensure the sprite is centered
        transform.position = Vector3.zero;

        // Calculate the screen size in world units
        float worldScreenHeight = Camera.main.orthographicSize * 2f;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        // Get the sprite's current size in world units
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr == null) return;
        float spriteWidth = sr.sprite.bounds.size.x;
        float spriteHeight = sr.sprite.bounds.size.y;

        // Calculate the scale factors
        Vector3 scale = transform.localScale;
        scale.x = worldScreenWidth / spriteWidth;
        scale.y = worldScreenHeight / spriteHeight;
        transform.localScale = scale;
    }
}