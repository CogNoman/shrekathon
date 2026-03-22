using UnityEngine;

public class ShooterMob : MonoBehaviour
{
    // public GameObject Tomato;
    public GameObject goodProjectile;  // good projectile added
    public GameObject badProjectile;  // bad projectile added
    public float projectileSpeed;
    public float fireRate = 1f;

    public float scrollSpeed = 2f;

    private float fireCooldown = 0f;
    private Transform playerTransform;

    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("BottomBorder"))
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        if (playerTransform == null)
        {
            
            PlayerScript player = FindAnyObjectByType<PlayerScript>();

            if (player != null) {
                playerTransform = player.transform;
            }

            return;

        }

        if (fireCooldown > 0f)
        {
            fireCooldown -= Time.deltaTime;
        }

        if (fireCooldown <= 0f)
        {
            Shoot();
            fireCooldown = fireRate;
        }

        // makes the shooter mobs move downwards
         transform.position = new Vector2(transform.position.x, transform.position.y - scrollSpeed * Time.deltaTime);

    }

    void Shoot()
    {
        // Vector2 direction = (playerTransform.position - transform.position).normalized;
        // GameObject tomato = Instantiate(Tomato, transform.position, Quaternion.identity);
        // tomato.GetComponent<Rigidbody2D>().linearVelocity = direction * projectileSpeed;

        Vector2 direction = (playerTransform.position - transform.position).normalized;
        GameObject prefabToSpawn;   // 80% chance bad projectile, 20% chance good projectile
        if (Random.value < 0.8f)
        {
            prefabToSpawn = badProjectile;
        }
        else
        {
            prefabToSpawn = goodProjectile;
        }

        GameObject projectile = Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().linearVelocity = direction * projectileSpeed;
    }
}
