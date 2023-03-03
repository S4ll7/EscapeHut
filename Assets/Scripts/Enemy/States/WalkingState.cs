using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class WalkingState : State
{
    [SerializeField] private Route _route;
    [SerializeField] private RichedEndPointTransition _walkingToWorking;
    
    private int _curentWalkingPointId;
    
    private void OnEnable()
    {
        _curentWalkingPointId = 0;
        _walkingToWorking.SetEndPoint(_route.RoutePoints[_route.RoutePoints.Count - 1]);
        Entity.SetDestination(_route.RoutePoints[_curentWalkingPointId]);
        GetComponent<Animator>().SetBool("IsWalking", true);
    }
    
    private void FixedUpdate()
    {
        if (Entity.RichedPoint(_route.RoutePoints[_curentWalkingPointId]))
        {
            if (_curentWalkingPointId < _route.RoutePoints.Count - 1)
            {
                _curentWalkingPointId++;
                Entity.SetDestination(_route.RoutePoints[_curentWalkingPointId]);
            }
        }
    }
}
