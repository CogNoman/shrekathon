using System;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float movementSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        // movement
        transform.Translate(new Vector2(moveX, moveY).normalized * movementSpeed * Time.deltaTime);
    }
}
