using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;

    private float _angleOfView = 0;
    
    public void UodateAngleOfView(float normalizedValue)
    {
        transform.rotation = Quaternion.Euler(0, normalizedValue * 180, 0);
        //transform.Rotate(0, normalizedValue, 0);
    }

    //private void Update()
    //{
    //    transform.Rotate(0,Input.GetAxis("Horizontal") * _rotationSpeed, 0);
    //}
}
