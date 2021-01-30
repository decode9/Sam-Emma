using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : Interactive
{
    public string portal;
    public string target;
    public PolygonCollider2D confiner;

    public override void Interact()
    {
        PortalManager.instance.Teleport(target);
    }

}
