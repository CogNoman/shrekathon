using UnityEngine;

public class mobSpawner : MonoBehaviour
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
        float minX = -7.22f, maxX = 1f;
        float minY = -4f, maxY = 4.3f;

        int wall = Random.Range(0, 4); // 0 = left, 1 = right, 2 = bottom, 3 top

        return wall switch
        {
            0 => new Vector2(minX, Random.Range(minY, maxY)), // left wall
            1 => new Vector2(maxX, Random.Range(minY, maxY)), // right wall
            2 => new Vector2(Random.Range(minX, maxX), minY),
            3 => new Vector2(Random.Range(minX, maxX), maxY),
            _ => Vector2.zero
        };
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnCooldown = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        gameTime += Time.deltaTime;

        // as time advances, the mobs will keep spawning faster
        minSpawnTime = Mathf.Max(0.8f, 3f - (0.06f * gameTime));
        maxSpawnTime = Mathf.Max(1.2f, 4f - (0.06f * gameTime));

        spawnCooldown -= Time.deltaTime;

        if (spawnCooldown <= 0f)
        {
            SpawnMob();
            spawnCooldown = Random.Range(minSpawnTime, maxSpawnTime);
        }
    }
    
}
