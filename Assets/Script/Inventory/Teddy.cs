using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Teddy : Interactive
{
    public Item item;

    public string text;
    public Color color;

    private SpriteRenderer sprite;

    private void OnValidate()
    {

        if (item)
        {
            sprite = GetComponent<SpriteRenderer>();
            sprite.sprite = item.artwork;
            sprite.color = color;
            text = item.description;
        }

    }

    public override void Interact()
    {
        Debug.Log(text);
    }
}
