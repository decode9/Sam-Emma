using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    protected float x;
    protected float y;
    [HideInInspector]
    public bool collision;
    protected AnimatorManager animatorManager;
    public GameObject player;

}
