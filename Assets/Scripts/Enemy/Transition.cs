using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Transition : MonoBehaviour
{
    [SerializeField] private State _nextState;

    private Player _target;
    private Enemy _entity;

    public bool NeedTransition;
    public State NextState => _nextState;
    public Player Target => _target;
    public Enemy Entity => _entity;

    public void Init(Player target, Enemy entety)
    {
        _target = target;
        _entity = entety;
    }

    private void OnEnable()
    {
        NeedTransition = false;
    }
}
