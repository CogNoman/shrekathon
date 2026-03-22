using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    private float damage;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // dealing dmg here
            if (gameObject.CompareTag("Tomato")) damage = 0.5f;
            else if (gameObject.CompareTag("Arrow")) damage = 0.75f;
            else if (gameObject.CompareTag("Pitchfork")) damage = 1f;
            else damage = 0f;
            
            Debug.Log("Player hit for projectile dmg " + damage);
            Destroy(gameObject);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
