using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Route : MonoBehaviour
{
    private List<Vector3> _routePoints = new List<Vector3>();

    public List<Vector3> RoutePoints => _routePoints;

    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            _routePoints.Add(transform.GetChild(i).transform.position);
        }
    }
    
}
