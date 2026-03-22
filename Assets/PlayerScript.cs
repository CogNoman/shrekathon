using System;
using System.Security.Cryptography;
// using System.Threading.Tasks.Dataflow;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float baseMovementSpeed, movementSpeedModifier, movementSpeed, armor, rageMeter, attackRadius = 2f, spinCooldown = 0f;
    public bool armored;
    public bool alive;
    public bool enraged;
    public AudioSource goodSound;
    public AudioSource badSound;
    public GameObject bloodSplat;

    private Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        alive = true;
        enraged = false;
        armored = false;
        baseMovementSpeed = 5f;
        movementSpeedModifier = 1f;

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movementSpeed = baseMovementSpeed * movementSpeedModifier;

        if (spinCooldown > 0f)
        {
            spinCooldown -= Time.deltaTime;
        }


        // When the player presses Space, and the spin cooldown is at 0 or less, it activates the spin attack, and sets cooldown to whatever it is
        if (Input.GetKeyDown(KeyCode.Space) && spinCooldown <= 0)
        {
            SpinAttack();
            spinCooldown = 2f;
        }

        // This method is the one for the spin attack.
        void SpinAttack()
        {
            Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, attackRadius);

            foreach (Collider2D hit in hits)
            {
                if (hit.GetComponent<mob>() != null)
                {
                    // make sure that when they die, they have a chance to drop equipment!
                    // add prefab for blood splatter
                    Debug.Log("Entity has been hit");
                    Instantiate(bloodSplat, hit.transform.position, Quaternion.identity);
                    Destroy(hit.gameObject);
                }
            }
        }

        if (armor <= 0)
        {
            armored = false;
        }
        else
        {
            armored = true;
        }



        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        // change anim speed based on movement direction
        if (moveY > 0.1f)
        {
            anim.SetFloat("animSpeed", 1.5f);
        }
        else if (moveY < -0.1f)
        {
            anim.SetFloat("animSpeed", 0.5f);
        }
        else
        {
            anim.SetFloat("animSpeed", 1.0f);
        }

        // movement
        transform.Translate(new Vector2(moveX, moveY).normalized * movementSpeed * Time.deltaTime);
    }

        // This method handles projectile collisions
        void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("GoodProjectile"))
        {
            Debug.Log("Hit by GOOD projectile");

            if (InventoryManager.Instance != null)
            {
                InventoryManager.Instance.AddRandomItem();
                goodSound.Play();
                Debug.Log("Inventory Item should be added now?");
            }
            else
            {
                Debug.LogWarning("InventoryManager not found (did you run the MAIN scene (which contains the Inventory Manager) or only the playerScene?)");
            }

            Destroy(other.gameObject); // remove projectile
        }

       else if (other.CompareTag("BadProjectile"))
        {
            float damage = other.GetComponentInParent<EnemyProjectile>().damage;
            Debug.Log("Hit by " + other.gameObject + " for " + damage);
            badSound.Play();
            // You can handle damage here later 
            Destroy(other.gameObject); // optional
        }
    }
}
