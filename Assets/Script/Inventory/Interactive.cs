using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(BoxCollider2D))]
public class Interactive : MonoBehaviour
{
    protected BoxCollider2D myCollider;
    public UnityEvent onInteraction;
    protected EmaController player;

    private void Start()
    {
        myCollider = GetComponent<BoxCollider2D>();
        myCollider.isTrigger = true;
        player = GameManager.instance.player.GetComponent<EmaController>();
    }

    private void Update()
    {
        if (player.gameObject.GetComponent<InputController>().interactuar) Interaction();
    }

    protected void Interaction()
    {

        foreach (RaycastHit2D interactive in player.Interaction())
        {
            if (interactive.collider.gameObject == gameObject) Interact();
        }
    }

    public virtual void Interact()
    {
        Debug.Log("Interaction");
    }
}
