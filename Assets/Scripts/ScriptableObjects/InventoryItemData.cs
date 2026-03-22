using UnityEngine;

[CreateAssetMenu(fileName = "InventoryItem", menuName = "ScriptableObjects/InventoryItem")]

public class InventoryItemData : ScriptableObject
{
    public string itemName;
    public Sprite inventoryIcon;
    public Sprite bigSprite;
    public Sprite projectileIcon;
}