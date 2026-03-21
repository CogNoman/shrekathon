using System;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float baseMovementSpeed, movementSpeedModifier, movementSpeed, armor, rageMeter;
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
