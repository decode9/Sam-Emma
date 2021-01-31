using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NextLevelQuest : Quest
{
    public override void Interact()
    {
        Debug.Log(ValidateItems());
        if(ValidateItems()) onInteraction.Invoke();
    }
}
