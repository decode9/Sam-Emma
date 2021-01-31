using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class SecondScreen : MonoBehaviour
{
    public UnityEvent onInteraction;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitScreen());
    }


    IEnumerator WaitScreen()
    {
        yield return new WaitForSeconds(10);
        onInteraction.Invoke();
    }
}
