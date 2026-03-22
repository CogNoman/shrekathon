using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public Vector2 minSpawnBounds;
    public Vector2 maxSpawnBounds;

    void Start()
    {
        if (InventoryManager.Instance != null)
        {
            InventoryManager.Instance.OnItemAdded += SpawnItem;
        }
    }

    void OnDestroy()
    {
        if (InventoryManager.Instance != null)
        {
            InventoryManager.Instance.OnItemAdded -= SpawnItem;
        }
    }

    void SpawnItem(InventoryItemData item)
    {
        Vector2 randomPos = new Vector2(
            Random.Range(minSpawnBounds.x, maxSpawnBounds.x),
            Random.Range(minSpawnBounds.y, maxSpawnBounds.y)
        );

        GameObject obj = new GameObject(item.itemName);
        var sr = obj.AddComponent<SpriteRenderer>();
        sr.sprite = item.bigSprite;

        obj.AddComponent<BoxCollider2D>(); 
        obj.AddComponent<DraggableItem>(); 

        obj.transform.position = randomPos;
    }
}