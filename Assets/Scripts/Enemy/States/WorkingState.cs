using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class WorkingState : State
{
    private void OnEnable()
    {
        GetComponent<Animator>().SetBool("IsWalking", false);
    }
}
