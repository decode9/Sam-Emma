using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StartScreen : MonoBehaviour
{

    public UnityEvent onInteraction;
    public Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }


    public void NextStage()
    {
        animator.SetBool("start", true);
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        onInteraction.Invoke();
    }



}
