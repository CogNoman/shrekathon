using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    public List<InventoryItemData> allPossibleItems = new List<InventoryItemData>();
    public List<InventoryItemData> collectedItems = new List<InventoryItemData>();
    //public List<InventoryItemData> equippedItems = new List<InventoryItemData>();

    public event Action<InventoryItemData> OnItemAdded; // Action to trigger spawning sprites
    public event Action<InventoryItemData> OnItemRemoved; // Action to trigger spawning sprites

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

        InventoryItemData chosen = available[UnityEngine.Random.Range(0, available.Count)];
        collectedItems.Add(chosen);

        Debug.Log("Collected: " + chosen.itemName);

        OnItemAdded?.Invoke(chosen); // Event being fired to trigger makeup sprite spawning
    }

    public void RemoveRandomItem()
    {
        if (collectedItems.Count == 0)
        {
            Debug.Log("No items to remove!");
            return;
        }

        int index = UnityEngine.Random.Range(0, collectedItems.Count);
        InventoryItemData removed = collectedItems[index];

        collectedItems.RemoveAt(index);

        Debug.Log("Removed: " + removed.itemName);

        OnItemRemoved?.Invoke(removed);
    }
}