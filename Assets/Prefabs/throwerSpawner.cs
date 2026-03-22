using UnityEngine;

public class throwerSpawner : MonoBehaviour
{
    public GameObject mob;
    public float minSpawnTime;
    public float maxSpawnTime;
    private float gameTime = 0f;
    public float spawnCooldown;
    void SpawnMob()
    {
        Vector2 spawnPoint = GetRandomWallPosition();
        Instantiate(mob, spawnPoint, Quaternion.identity);
    }

    Vector2 GetRandomWallPosition()
    {
        float minX = -6.5f, maxX = 0.7f;
        float maxY = 4.1f;

        int wall = Random.Range(0, 2); // 0 = left, 1 = right

        return wall switch
        {
            0 => new Vector2(minX, maxY), // left wall
            1 => new Vector2(maxX, maxY), // right wall
            _ => Vector2.zero
        };
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnCooldown = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        gameTime += Time.deltaTime;

        // as time advances, the mobs will keep spawning faster
        minSpawnTime = Mathf.Max(0.8f, 2.2f - (0.03f * gameTime));
        maxSpawnTime = Mathf.Max(1.2f, 3.2f - (0.03f * gameTime));

        spawnCooldown -= Time.deltaTime;

        if (spawnCooldown <= 0f)
        {
            SpawnMob();
            spawnCooldown = Random.Range(minSpawnTime, maxSpawnTime);
        }
    }
    
}
