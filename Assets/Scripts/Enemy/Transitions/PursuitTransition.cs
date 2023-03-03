using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PursuitTransition : Transition
{
    private void FixedUpdate()
    {
        if(Entity.ObjectIntoView(Target.GetKidsPosition()))
        {
            if (Target.LocateKids(transform.position))
            {
                NeedTransition = true;
            }
        }
    }
}
