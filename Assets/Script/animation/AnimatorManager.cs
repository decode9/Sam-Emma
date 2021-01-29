using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    public static AnimatorManager instance;
    public bool start { get; private set; }

    public string stage { get; private set; }

    private void Awake()
    {
        if (!instance) instance = this;
    }

    private void Start() {
        Prologue();
    }

    public void Prologue(){
        start = true;
        stage = "prologue";
    }

    public void StopAnimation(){
        start = false;
        stage = null;
    }
}
