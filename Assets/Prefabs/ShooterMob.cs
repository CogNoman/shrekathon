using UnityEngine;

public class ShooterMob : MonoBehaviour
{
    // public GameObject Tomato;
    public GameObject goodProjectile;  // good projectile added
    public GameObject badProjectile;  // bad projectile added
    public float projectileSpeed = 6f;
    public float fireRate = 1f;

    private float fireCooldown = 0f;
    private Transform playerTransform;

    void Start()
    {
        PlayerScript player = FindAnyObjectByType<PlayerScript>();
        playerTransform = player.transform;
    }


    void Update()
    {
        if (fireCooldown > 0f)
        {
            fireCooldown -= Time.deltaTime;
        }

        if (fireCooldown <= 0f)
        {
            Shoot();
            fireCooldown = fireRate;
        }
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
