using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachina : MonoBehaviour
{
    [SerializeField] private State _startState;
    [SerializeField] private Player _target;
    [SerializeField] private Enemy _entity;


    private State _curentState;
    private State _nextState;

    private void Start()
    {
        _curentState = _startState;
        if (_curentState != null)
        {
            _curentState.Enter(_target, _entity);
        }
    }
    
    private void Update()
    {
        _nextState = _curentState.GetNextState();
        if (_nextState != null)
        {
            _curentState.Exit();
            _curentState = _nextState;
            _curentState.Enter(_target, _entity);
        }
    }
}
