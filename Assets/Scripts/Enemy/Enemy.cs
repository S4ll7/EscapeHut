using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent)), RequireComponent(typeof(Animator))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _walkSpeed;
    [SerializeField] private float _runSpeed;
    [SerializeField] private float _halfAngleOfView;
    [SerializeField] private float _angleOfViewExpand;

    private float _curentHalfAngleOfView;
    private NavMeshAgent _navMeshAgent;
    
    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _curentHalfAngleOfView = _halfAngleOfView;
    }

    public void SetDestination(Vector3 destination)
    {
        _navMeshAgent.SetDestination(destination);
    }

    public bool ObjectIntoView(Vector3 objectPosition)
    {
        Vector3 targetDirection = objectPosition - transform.position;
        float angle = Vector3.Angle(transform.forward, targetDirection.normalized);
        if (angle < _curentHalfAngleOfView)
        {
            return true;
        }
        return false;
    }

    public void ExpandFieldOfView()
    {
        _curentHalfAngleOfView += _angleOfViewExpand;
    }

    public void RecoverFieldOfView()
    {
        _curentHalfAngleOfView = _halfAngleOfView;
    }

    public bool RichedPoint(Vector3 pointPosition)
    {
        if ((transform.position - pointPosition).sqrMagnitude <= 0.1f)
        {
            return true;
        }
        return false;
    }

    public void ChangeSpeed(bool isRunning)
    {
        if (isRunning)
        {
            _navMeshAgent.speed = _runSpeed; 
        }
        else
        {
            _navMeshAgent.speed = _walkSpeed;
        }
    }
}
