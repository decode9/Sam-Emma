using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(BoxCollider2D))]
public class Object : Interactive
{
    public Item item;
    private SpriteRenderer spriteRenderer;
    public int amount = 1;

    private void OnValidate() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        myCollider = GetComponent<BoxCollider2D>();
        gameObject.name = item.itemName;
        spriteRenderer.sprite = item.artwork;
        myCollider.size = new Vector2(1,1);
    }

    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<BoxCollider2D>();
        player = GameManager.instance.player.GetComponent<EmaController>();
        myCollider.isTrigger = true;
        myCollider.size = new Vector2(1,1);
        gameObject.layer = 10;
    }

    public override void Interact(){
        
        if(Inventory.instance.AddObject(item,amount)) Destroy(gameObject);
    }
}
