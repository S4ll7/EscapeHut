using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    [SerializeField] private List<Kid> _kids;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private int _numberOfKidsForEscape;

    private bool _isAllowedToEscape;
    private Camera _camera;

    public bool IsAllowedToEscape => _isAllowedToEscape;

    private void Start()
    {
        _isAllowedToEscape = false;
        _camera = Camera.main;
    }

    private void OnEnable()
    {
        foreach (Kid kid in _kids)
        {
            kid.RichedTargetPosition += StopKidsMovment;
        }
    }

    private void OnDisable()
    {
        foreach (Kid kid in _kids)
        {
            kid.RichedTargetPosition -= StopKidsMovment;
        }
    }

    private void StopKidsMovment()
    {
        foreach (Kid kid in _kids)
        {
            kid.Motion(kid.transform.position);
        }
    }

    private void MoveKids(Vector3 newPosition)
    {
        // !!!!!!!!!!!!!!
        //_kids[0].Motion(newPosition);
        //for (int i = 1; i < _kids.Count; i++)
        //{
        //    float degree = Random.Range(0,360);
        //    Vector3 curentKidPosition = newPosition;
        //    curentKidPosition.x = newPosition.x + Mathf.Cos(degree) * 1f;
        //    curentKidPosition.z = newPosition.z + Mathf.Sin(degree) * 1f;
        //    NavMesh.SamplePosition(curentKidPosition, out NavMeshHit hit, 1f, NavMesh.AllAreas);
        //    _kids[i].Motion(hit.position);
        //    Debug.Log(hit.position);
        //}
        NavMesh.SamplePosition(newPosition, out NavMeshHit hit, 0.5f, NavMesh.AllAreas);
        foreach (Kid kid in _kids)
        {
            kid.Motion(hit.position);
        }
    }

    public bool LocateKids(Vector3 observerPosition)
    {
        foreach (Kid kid in _kids)
        {
            Vector3 targetDirection = kid.transform.position - observerPosition;
            if (Physics.Raycast(observerPosition, targetDirection, out RaycastHit hit, 20, _layerMask))
            {
                if (hit.collider.gameObject.TryGetComponent<Kid>(out Kid detectedKid))
                {
                    return true;
                }
            }
        }
        return false;
    }

    private void Rescue(bool isFreeing)
    {
        foreach (Kid kid in _kids)
        {
            kid.Rescue(isFreeing);
        }
    }

    public void StartRescue()
    {
        Rescue(true);
    }

    public void StopRescue()
    {
        Rescue(false);
    }

    public Vector3 GetKidsPosition()
    {
        Vector3 centre = Vector3.zero;
        foreach (Kid kid in _kids)
        {
            centre += kid.gameObject.transform.position;
        }
        return centre / _kids.Count;
    }

    public void AddKid(Kid kid)
    {
        kid.transform.parent = transform;
        _kids.Add(kid);
        kid.RichedTargetPosition += StopKidsMovment;
        AllowToEscape();
    }

    private void AllowToEscape()
    {
        if (_kids.Count >= _numberOfKidsForEscape)
        {
            _isAllowedToEscape = true;
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (!EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out hit, 100, _layerMask))
            {
                if (hit.collider.TryGetComponent<Floor>(out Floor floor))
                {
                    MoveKids(hit.point);
                }
            }
        }
    }
}
