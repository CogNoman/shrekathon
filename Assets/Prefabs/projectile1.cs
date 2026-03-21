using UnityEngine;

public class projectile1 : MonoBehaviour
{

    public float projectileDamage, projectileSpeed, rotationSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        print("start!");
        rotationSpeed = Random.Range(180f, 720f);
    }

    // Update is called once per frame
    void Update()
    {
        print("update");

        // transform.Translate(Vector2.up * projectileSpeed * Time.deltaTime);
       // transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
