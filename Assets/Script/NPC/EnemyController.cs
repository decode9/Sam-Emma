using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public float waitTime;
    public float startWaitTime;

    public Transform moveSpot;

    void Start()
    {
        waitTime = startWaitTime;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpot.position, speed * Time.deltaTime);

        if(Vector2.Distance(transform.position, moveSpot.position) < 0.2f)
        {
            if(waitTime <= 0)
            {
                waitTime = startWaitTime;
            } 
            else 
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
}
