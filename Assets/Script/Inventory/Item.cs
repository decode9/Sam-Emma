using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Items/GenericItem")]
public class Item : ScriptableObject
{
    public Sprite artwork;
    public string itemName;
    public bool apilable;
    [TextArea(1, 3)]
    public string description;

    public virtual bool useItem()
    {
        Debug.Log("using item " + itemName);
        return true;
    }

}
