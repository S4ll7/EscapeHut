using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PursuitState : State
{
    private void OnEnable()
    {
        GetComponent<Animator>().SetBool("PursuitStarted", true);
        Entity.ChangeSpeed(true);
    }

    private void FixedUpdate()
    {
        Entity.SetDestination(Target.GetKidsPosition());
    }
}
