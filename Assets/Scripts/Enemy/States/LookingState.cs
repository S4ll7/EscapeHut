using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LookingState : State
{
    [SerializeField] private Route _points;
    [SerializeField] private RichedEndPointTransition _walkEnd;

    private int _previousNumber = -1;

    private void OnEnable()
    {
        Vector3 destination = GeneratePoint();
        Entity.SetDestination(destination);
        _walkEnd.SetEndPoint(destination);
    }

    private Vector3 GeneratePoint()
    {
        int pointIndex = Random.Range(0, _points.RoutePoints.Count);
        if (pointIndex == _previousNumber)
        {
            pointIndex++;
            pointIndex %= _points.RoutePoints.Count;
        }
        _previousNumber = pointIndex;
        return _points.RoutePoints[pointIndex];
    }
    
}
