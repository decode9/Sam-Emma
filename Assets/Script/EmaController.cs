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
    private SpriteRenderer spriteRenderer;
    private CapsuleCollider2D myCollider;
    public LayerMask layerInteraction;

    public float speedRate = 2f;

    void Start()
    {
        InputPlayer = GetComponent<InputController>();
        myRigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        myCollider = GetComponent<CapsuleCollider2D>();
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

            if (movimiento[0] < 0 && Mathf.Abs(movimiento[1]) < Mathf.Abs(movimiento[0])) spriteRenderer.flipX = true;
            else spriteRenderer.flipX = false;
        }

        else
        {
            animator.SetBool("run", false);
        }
    }
    public RaycastHit2D[] Interaction()
    {
        RaycastHit2D[] circleCast = Physics2D.CircleCastAll(transform.position, myCollider.shapeCount, InputPlayer.lookDirection.normalized, 0f, layerInteraction);
        if (circleCast != null) return circleCast;
        return null;
    }
}
