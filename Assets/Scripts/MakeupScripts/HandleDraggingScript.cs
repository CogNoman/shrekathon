using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using static UnityEngine.Rendering.DebugUI.Table;

public class HandleDraggingScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject cursorGhostObject;
    public GameObject inventoryGrid;
    //public GameObject itemPrefab;
    private Vector3 mousePosition;

    public void OnPointerClick(PointerEventData eventData)
    {
        // This method is called when the UI element is clicked
        Debug.Log("Clicked on: " + this.gameObject.name);

        // You can access other data from eventData if needed
        // eventData.pointerCurrentRaycast.gameObject.name;
    }

    void DragItem()
    {
        cursorGhostObject.SetActive(true);
    }
    void DropItem()
    {
        cursorGhostObject.SetActive(false);
    }

    //void Start()
    //{
    //    cursorGhostObject.SetActive(false);
    //    // temp code to create a grid of items in the inventory canvas
    //    for (int i = 0; i < 2 * 6; i++)
    //    {
    //        GameObject newItem = Instantiate(itemPrefab, this.transform);
    //        newItem.name = "GridItem_" + i;
    //    }
    //}

    void Update()
    {
        mousePosition = Input.mousePosition;
        cursorGhostObject.transform.position = mousePosition;
        if (Input.GetMouseButtonDown(0)) DragItem();
        else if (Input.GetMouseButtonUp(0)) DropItem();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerCurrentRaycast.gameObject.name);
    }

    public void OnDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
