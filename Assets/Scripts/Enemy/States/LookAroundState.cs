using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAroundState : State
{
    private void OnEnable()
    {
        Entity.SetDestination(transform.position);
        Entity.ExpandFieldOfView();
        GetComponent<Animator>().SetBool("NeedToLookAround", true);
    }

    private void OnDisable()
    {
        Entity.RecoverFieldOfView();
    }
}
