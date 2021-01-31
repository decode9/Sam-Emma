using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmaController : MonoBehaviour
{

    // private InputController inputJugador;
    private InputController InputPlayer;
    private Animator animator;
    private Rigidbody2D myRigid;
    private float[] movimiento = new float[2];
    public SpriteRenderer spriteRenderer;

    public float speedRate = 2f;

    void Start()
    {
        InputPlayer = GetComponent<InputController>();
        myRigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {   
        movePlayer();
    }

    void movePlayer()
    {
        movimiento = InputPlayer.vector;

        Animation(movimiento);
        // ---- Movimiento de Cuerpo Rigido ---- //
        Vector2 velocityVector = new Vector2(movimiento[0], movimiento[1]) * speedRate;
        // if (animator.GetBool(attackHash)) velocityVector = Vector2.zero;

        //myRigid.AddForce(velocityVector);Debug
        myRigid.velocity = velocityVector;
    }

    void Animation(float[] movimiento)
    {
        bool run = (movimiento[1] != 0 || movimiento[0] != 0);
        animator.SetBool("run", run);

        if (run)
        {
            animator.SetFloat("x", movimiento[0]);
            animator.SetFloat("y", movimiento[1]);

            if(movimiento[0] < 0 && Mathf.Abs(movimiento[1]) < Mathf.Abs(movimiento[0])) spriteRenderer.flipX = true;
            else spriteRenderer.flipX = false;
        }

        else
        {
            animator.SetBool("run", false);
        }
    }
}
