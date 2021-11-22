using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector3 _targetposition;
    private bool _startMove;

    private void Awake()
    {
        _targetposition = new Vector3(transform.position.x, transform.position.y, transform.position.z - 25f);
    }

    private void Update()
    {
        if (transform.position != _targetposition && _startMove)
        {
            transform.position = Vector3.Lerp(transform.position, _targetposition, _speed * Time.deltaTime);
        }
    }

    public void StartMove()
    {
        _startMove = true;
    }
}
