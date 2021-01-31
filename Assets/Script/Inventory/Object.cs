using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(BoxCollider2D))]
public class Object : Interactive
{
    public Item item;
    private SpriteRenderer spriteRenderer;
    public int amount = 1;
    Animator animator;
    AudioSource audio; 

    private void OnValidate() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        myCollider = GetComponent<BoxCollider2D>();
        gameObject.name = item.itemName;
        spriteRenderer.sprite = item.artwork;
        myCollider.size = new Vector2(1,1);
    }

    void Start()
    {
        myCollider = GetComponent<BoxCollider2D>();
        player = GameManager.instance.player.GetComponent<EmaController>();
        myCollider.isTrigger = true;
        myCollider.size = new Vector2(1,1);
        gameObject.layer = 10;
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    public override void Interact(){
        animator.SetBool("taked", true);
        audio.Play();
        if(Inventory.instance.AddObject(item,amount)) Destroy(gameObject);
    }
}
