using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    [SerializeField] private List<Transition> _transitions;

    private Player _target;
    private Enemy _entity;
    
    public Player Target => _target;
    public Enemy Entity => _entity;

    public void Enter(Player target, Enemy entity)
    {
        _target = target;
        _entity = entity;
        enabled = true;
        foreach (Transition transition in _transitions)
        {
            transition.Init(_target, _entity);
            transition.enabled = true;
        }
    }

    public void Exit()
    {
        foreach (Transition transition in _transitions)
        {
            transition.enabled = false;
        }
        enabled = false;
    }

    public State GetNextState()
    {
        foreach (Transition transition in _transitions)
        {
            if (transition.NeedTransition)
            {
                return transition.NextState;
            }
        }
        return null;
    }
}
