using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float movementSpeed = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector2 movement = new Vector3(moveX, moveY) * movementSpeed * Time.deltaTime;
        transform.Translate(movement);
    }
}
