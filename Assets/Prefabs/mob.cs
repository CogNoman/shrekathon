using Unity.VisualScripting;
using UnityEngine;

public class mob : MonoBehaviour
{

    public float attackDamage, attackCooldown, movementSpeed;
    public bool alive;

    private SpriteRenderer sr;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private Transform playerTransform;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        
        PlayerScript player = FindAnyObjectByType<PlayerScript>();
        playerTransform = player.transform;
        alive = true;
        attackDamage = 0.75f;
        attackCooldown = 1;
        movementSpeed = player.baseMovementSpeed * 0.6f;
        Debug.Log("mob is spawned");
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform == null)
        {
            PlayerScript player = FindAnyObjectByType<PlayerScript>();
            if (player != null)
            {
                playerTransform = player.transform;
            }
            return;

        }
        Vector2 direction = (playerTransform.position - transform.position).normalized;

        float distance = Vector2.Distance(playerTransform.position, transform.position);

        if (attackCooldown > 0f)
        {
            attackCooldown -= Time.deltaTime;
        }

        // movement of the mob towards the player

        transform.Translate(direction * movementSpeed * Time.deltaTime);
        if (attackCooldown <= 0f) // if in range, attacks
        {
            // deal damage to player
            Debug.Log("Player hit for melee damage " + attackDamage);
            attackCooldown = 1f;
        }


        if (transform.position.x < playerTransform.position.x) {
            sr.flipX = true;
        } else {
            sr.flipX = false;
        }
    }
}
