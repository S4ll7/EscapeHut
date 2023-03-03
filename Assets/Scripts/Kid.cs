using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[RequireComponent(typeof(Animator)), RequireComponent(typeof(NavMeshAgent))]
public class Kid : MonoBehaviour
{
    [SerializeField] private bool _isJailed;
    [SerializeField] private bool _isFreeing;

    private Animator _animator;
    private NavMeshAgent _navMeshAgent;
    private Vector3 _targetPosition;

    public bool IsJailed => _isJailed;
    public UnityAction RichedTargetPosition;

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _animator.SetBool("IsJailed", _isJailed);
        _targetPosition = transform.position;
    }

    public void Motion(Vector3 newPosition)
    {
        _targetPosition = newPosition;
        _navMeshAgent.SetDestination(newPosition);
    }

    public void Rescue(bool isFreeing)
    {
        _animator.SetBool("IsFreeing", isFreeing);
    }

    public void Escape()
    {
        _animator.SetBool("IsJailed", false);
    }

    private void Update()
    {
        _animator.SetFloat("Speed", _navMeshAgent.velocity.magnitude / _navMeshAgent.speed);
        if ((transform.position - _targetPosition).sqrMagnitude < 0.05f)
        {
            RichedTargetPosition?.Invoke();
        }
    }
}
