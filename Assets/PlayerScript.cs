using System;
using System.Security.Cryptography;
using System.Threading.Tasks.Dataflow;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float baseMovementSpeed, movementSpeedModifier, movementSpeed, armor, rageMeter, attackRadius = 2f, spinCooldown = 0f;
    public bool armored;
    public bool alive;
    public bool enraged;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        alive = true;
        enraged = false;
        armored = false;
        baseMovementSpeed = 8f;
        movementSpeedModifier = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        movementSpeed = baseMovementSpeed * movementSpeedModifier;

        if (spinCooldown > 0f)
        {
            spinCooldown -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space) && spinCooldown <= 0)
        {
            SpinAttack();
            spinCooldown = 4f;
        }

        void SpinAttack()
        {
            Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, attackRadius);

            foreach (Collider2D hits in hits)
            {
                if (hits.CompareTag("Enemy"))
                {
                    // placeholder effect, should change texture. and make them immobile
                    // i stopped here, resume! also removes their hitbox so things can pass through.
                    // make sure that when they die, they have a chance to drop equipment!
                    hits.alive = false;
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

        // movement
        transform.Translate(new Vector2(moveX, moveY).normalized * movementSpeed * Time.deltaTime);
    }
}
