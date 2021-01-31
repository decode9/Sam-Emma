using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatronController : MonoBehaviour
{
    public Transform[] spots;
    public float speed;
    public float waitTime;
    public bool isFlipped = true;

    private float startWaitTime;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private int pointTarget = 1;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        startWaitTime = waitTime;
    }

    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, spots[pointTarget].position, speed * Time.deltaTime);
        Animate();
        WaitMove();
    }

    private void WaitMove()
    {
        if(Vector2.Distance(transform.position, spots[pointTarget].position) < 0.2f)
        {
            if(startWaitTime <= 0)
            {
                pointTarget = pointTarget == 1 ? 0 : 1;
                isFlipped = isFlipped == true ? false : true;
                startWaitTime = waitTime;
            } 
            else 
            {
                animator.SetBool("run", false);
                startWaitTime -= Time.deltaTime;
            }
        }
    }

    private void Animate()
    {
        Vector2 position = transform.position;

        animator.SetBool("run", true);
        animator.SetFloat("x", position[0]);

        spriteRenderer.flipX = isFlipped;
    }
}
