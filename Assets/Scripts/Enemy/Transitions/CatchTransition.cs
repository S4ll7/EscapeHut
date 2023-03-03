using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchTransition : Transition
{
    private void FixedUpdate()
    {
        if ((transform.position - Target.GetKidsPosition()).magnitude < 1.2f)
        {
            NeedTransition = true;
        }
    }
}
