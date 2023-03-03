using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class FreeButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public UnityAction FreeStarted;
    public UnityAction FreeEnded;

    public void OnPointerDown(PointerEventData eventData)
    {
        FreeStarted?.Invoke();       
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        FreeEnded?.Invoke();
    }
}
