using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boy : Quest
{
    public override void Interact()
    {
        Debug.Log(ValidateItems());
    }
}
