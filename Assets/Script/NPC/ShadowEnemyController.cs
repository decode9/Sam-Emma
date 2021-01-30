using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowEnemyController : MonoBehaviour
{
    public GameObject target;
    public float subtractSpeed = .001f;
    public float speed;

    private EmaController emaController;
    private Transform moveSpot;

    void Start()
    {
        emaController = target.GetComponent<EmaController>();
        moveSpot = target.transform;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpot.position, speed * Time.deltaTime);

        if(Vector2.Distance(transform.position, moveSpot.position) < 0.2f)
        {
            if(emaController.speedRate > 0)
            {
                emaController.speedRate -= subtractSpeed;
            }
        }
    }
}
