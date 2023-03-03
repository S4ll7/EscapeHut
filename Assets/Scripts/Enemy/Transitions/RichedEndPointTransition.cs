using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RichedEndPointTransition : Transition
{
    private Vector3 _walkingEndPoint;
    private Vector3 _EmptyVector;
    
    public void SetEndPoint(Vector3 point)
    {
        _walkingEndPoint = point;
    }

    private void OnDisable()
    {
        _walkingEndPoint = _EmptyVector;
    }

    private void Update()
    {
        if (Entity.RichedPoint(_walkingEndPoint))
        {
            NeedTransition = true;
        }
    }
}
