using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : Interactive
{

    public Light lampLight;

    public override void Interact()
    {
        lampLight.intensity = (lampLight.intensity == 0) ? 1 : 0;
    }
}
