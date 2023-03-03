using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopLookingAroundTransition : Transition
{
    [SerializeField] private float _timeToLookAround;

    private float _curentTime;

    private void FixedUpdate()
    {
        _curentTime += Time.deltaTime;
        if (_curentTime > _timeToLookAround)
        {
            _curentTime = 0;
            NeedTransition = true;
            GetComponent<Animator>().SetBool("NeedToLookAround", false);
        }
    }
}
