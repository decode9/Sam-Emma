using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(BoxCollider2D))]
public class Object : Quest
{
    public Item item;
    private SpriteRenderer spriteRenderer;
    public int amount = 1;
    Animator animator;
    AudioSource source;
    private void OnValidate()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        myCollider = GetComponent<BoxCollider2D>();
        gameObject.name = item.itemName;
        spriteRenderer.sprite = item.artwork;
        myCollider.size = new Vector2(1, 1);
        source = GetComponent<AudioSource>();
    }

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        myCollider = GetComponent<BoxCollider2D>();
        player = GameManager.instance.player.GetComponent<EmaController>();
        myCollider.isTrigger = true;
        myCollider.size = new Vector2(1, 1);
        gameObject.layer = 10;
        animator = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
    }

    public override void Interact()
    {
        bool validation = (items.Length > 0) ? ValidateItems() : true;
        if (validation)
        {
            spriteRenderer.sortingLayerName = "decoration";
            spriteRenderer.sortingOrder = 2;
            if (animator) animator.SetBool("taked", true);
            if (source) source.Play();
            if (Inventory.instance.AddObject(item, amount)) Destroy(gameObject);
        }

    }
}
