using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    public static PortalManager instance;
    public Portal[] portals;

    private void Awake()
    {
        if (!instance) instance = this;
        if (instance) Destroy(this);
    }

    public void Teleport(string target)
    {
        GameManager gameManager = GameManager.instance;
        Portal portal = Array.Find(portals, ele => ele.portal == target);
        gameManager.player.GetComponent<Transform>().position = portal.transform.position;

    }

}
