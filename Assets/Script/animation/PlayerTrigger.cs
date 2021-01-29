using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    private AnimatorManager animatorManager;

    private void Start()
    {
        animatorManager = AnimatorManager.instance;
    }


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (animatorManager)
        {
            PrologueAnimation prologue = animatorManager.gameObject.GetComponent<PrologueAnimation>();
            if (collider.gameObject.CompareTag("chock")) prologue.collision = true;

            if (collider.gameObject.CompareTag("end"))
            {
                prologue.run = false;
                animatorManager.StopAnimation();
                prologue.DisplaySmoke();
            }
        }
    }
}
