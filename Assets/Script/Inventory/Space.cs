using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Space : MonoBehaviour, IPointerDownHandler
{
    public int amountStock;
    public Item saveItem;
    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }
    // Start is called before the first frame update
    void Start()
    {
        image.enabled = (saveItem);
    }

    public void AddObject(Item item, int amount)
    {
        saveItem = item;
        amountStock = amount;
        image.enabled = true;
        image.sprite = item.artwork;
    }

    public virtual void RemoveObject()
    {
        Inventory.instance.RemoveObject(saveItem);
        ResetSpace();
    }

    public void ResetSpace()
    {
        saveItem = null;
        amountStock = 0;
        image.enabled = false;
        image.sprite = null;
    }

    protected virtual void useObject()
    {
        if (saveItem)
        {
            if (saveItem.useItem())
            {
                ReduceStock(1);
            }
        }
    }

    void ReduceStock(int amount)
    {
        amountStock -= amount;
        if (amountStock <= 0)
        {
            RemoveObject();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        useObject();
    }
}
