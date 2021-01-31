using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool inventoryFull;
    public static Inventory instance;
    private Space[] spaces;
    private List<Item> objects = new List<Item>();
    private int emptySpace = 0;

    private void Awake()
    {
        if (!instance) instance = this;
        spaces = GetComponentsInChildren<Space>();
    }

    void DeterminateNextEmptySpace()
    {
        emptySpace = 0;
        foreach (Space space in spaces)
        {
            if (space.saveItem) emptySpace++;
            if(!space.saveItem) break;
        }

        inventoryFull = (emptySpace >= spaces.Length);
    }

    public bool AddObject(Item item, int amount)
    {
        DeterminateNextEmptySpace();
        if (((item.apilable && !objects.Contains(item)) && !inventoryFull) || (!item.apilable && !inventoryFull))
        {
            Space addSpace = spaces[emptySpace];
            objects.Add(item);
            addSpace.AddObject(item, amount);
            return true;
        }
        if (item.apilable && objects.Contains(item))
        {

            for (int index = 0; index < spaces.Length; index++)
            {
                if (item == spaces[index].saveItem)
                {
                    spaces[index].amountStock += amount;
                    break;
                }
            }
            return true;
        }
        Debug.Log("Inventory is full");
        return false;
    }

    public void RemoveObject(Item item)
    {
        objects.Remove(item);
    }
}
