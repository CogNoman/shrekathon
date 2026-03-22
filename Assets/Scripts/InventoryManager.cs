using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    public List<InventoryItemData> allPossibleItems = new List<InventoryItemData>();
    public List<InventoryItemData> collectedItems = new List<InventoryItemData>();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // persists across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddRandomItem()
    {
        // Filter items not yet collected
        List<InventoryItemData> available = new List<InventoryItemData>();

        foreach (var item in allPossibleItems)
        {
            if (!collectedItems.Contains(item))
                available.Add(item);
        }

        if (available.Count == 0)
        {
            Debug.Log("All items already collected!");
            return;
        }

        InventoryItemData chosen = available[Random.Range(0, available.Count)];
        collectedItems.Add(chosen);

        Debug.Log("Collected: " + chosen.itemName);
    }
}