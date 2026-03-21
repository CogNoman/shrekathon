using UnityEngine;

public class mob : MonoBehaviour
{

    public float attackDamage, attackSpeed, movementSpeed;
    public bool alive;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private Transform playerTransform;

    void Start()
    {
        PlayerScript player = FindAnyObjectByType<PlayerScript>();
        playerTransform = player.transform;
        alive = true;
        attackDamage = 0.75f;
        attackSpeed = 1;
        movementSpeed = player.baseMovementSpeed * 0.6f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = (playerTransform.position - transform.position).normalized;
        transform.Translate(direction * movementSpeed * Time.deltaTime);

    }
}
