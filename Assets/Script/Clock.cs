using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Clock : MonoBehaviour
{
    TextMeshProUGUI myClock;
    public static int count = 40; 

    void Start() {
        myClock = GetComponent<TMPro.TextMeshProUGUI>();
        StartCoroutine("Counter");
    }

     public IEnumerator Counter() {
         for(int i = count; i >= 0; i--) {
             
            myClock.text =  $"Time left: {i.ToString()}";
            if(i == 0) { 
                Time.timeScale = 0;
            }
             yield return new WaitForSeconds (1f);
         }
    }
}
