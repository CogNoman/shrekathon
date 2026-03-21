using UnityEngine;

public class mobSpawner : MonoBehaviour
{

    public GameObject mob;
    public float minSpawnTime = 2f;
    public float maxSpawnTime = 3f;

    public float spawnCooldown;
    void SpawnMob()
    {
        Vector2 spawnPoint = GetRandomWallPosition();
        Instantiate(mob, spawnPoint, Quaternion.identity);
    }

    Vector2 GetRandomWallPosition()
    {
        float minX = -8f, maxX = 8f;
        float minY = -5f, maxY = 5f;

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

    }

    // Update is called once per frame
    void Update()
    {
        spawnCooldown -= Time.deltaTime;

        if (spawnCooldown <= 0f)
        {
            SpawnMob();
            spawnCooldown = Random.Range(minSpawnTime, maxSpawnTime);
        }
    }
    
}
