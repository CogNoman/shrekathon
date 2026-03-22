using UnityEngine;
using TMPro;

public class InventoryCounterUI : MonoBehaviour
{
    public TextMeshProUGUI counterText;

    private int count = 0;

    void Start()
    {
        UpdateText();

        if (InventoryManager.Instance != null)
        {
            InventoryManager.Instance.OnItemAdded += OnItemAdded;
        }
    }

    void OnDestroy()
    {
        if (InventoryManager.Instance != null)
        {
            InventoryManager.Instance.OnItemAdded -= OnItemAdded;
        }
    }

    void OnItemAdded(InventoryItemData item)
    {
        count++;
        UpdateText();
    }

    void UpdateText()
    {
        counterText.text = count.ToString();
    }
}