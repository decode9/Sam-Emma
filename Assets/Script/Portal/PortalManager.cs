using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class PortalManager : MonoBehaviour
{
    public static PortalManager instance;
    public Portal[] portals;

    private int coldown = 2;

    private bool active;

    private void Awake()
    {
        if (!instance) instance = this;
    }

    public void Teleport(string target)
    {
        if (!active)
        {
            active = true;
            GameManager gameManager = GameManager.instance;
            Portal portal = Array.Find(portals, ele => ele.portal == target);
            gameManager.player.GetComponent<Transform>().position = portal.transform.position;
            CinemachineConfiner camConfiner = GameManager.instance.vCam.GetComponent<CinemachineConfiner>();
            camConfiner.m_BoundingShape2D = portal.confiner;
            StartCoroutine(ColdDown());
        }

    }

    IEnumerator ColdDown()
    {
        for (int i = 0; i < coldown; i++)
        {
            yield return new WaitForEndOfFrame();

        }
        active = false;
    }

}
