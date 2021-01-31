using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Quest : Interactive
{
    public Item[] items;

    public bool ValidateItems()
    {
        bool validate = true;
        Inventory inventory = Inventory.instance;
        if(inventory.objects.Count == 0) validate = false;
        foreach (Item inventoryItem in inventory.objects)
        {
            Item match = Array.Find(items, obj => inventoryItem == obj);
            validate = validate && (Array.Find(items, obj => inventoryItem == obj));
        }

        return validate;
    }
}
