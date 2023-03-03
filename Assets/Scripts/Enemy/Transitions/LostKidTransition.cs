using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LostKidTransition : Transition
{
    [SerializeField] private Jail _jail;

    private void FixedUpdate()
    {
        if(Entity.ObjectIntoView(_jail.transform.position))
        {
            if (Physics.Raycast(transform.position, (_jail.transform.position - transform.position).normalized, out RaycastHit hit))
            {
                if (hit.collider.TryGetComponent<Jail>(out Jail jail))
                {
                    if (!_jail.IsJailFull)
                    {
                        NeedTransition = true;
                    }
                }
            }
            
        }
    }
}
