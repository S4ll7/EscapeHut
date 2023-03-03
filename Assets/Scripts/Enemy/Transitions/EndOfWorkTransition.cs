using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfWorkTransition : Transition
{
    [SerializeField] private float _timeToWork;
    
    private float _curentTime = 0;

    private void FixedUpdate()
    {
        _curentTime += Time.deltaTime;
        if (_curentTime > _timeToWork)
        {
            _curentTime = 0;
            NeedTransition = true;
        }
    }
}
