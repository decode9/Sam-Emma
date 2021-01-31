using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class itemTrigger : MonoBehaviour
{   
    Animator animator; 
    AudioSource source;

    void Start() {
        animator = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("player")) {
            animator.SetBool("taked", true);
            source.Play();
            Destroy(gameObject, 1f);
        }
    }
}
