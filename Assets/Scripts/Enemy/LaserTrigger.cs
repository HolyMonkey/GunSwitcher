using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTrigger : MonoBehaviour
{
    private Enemy _current;

    private void Start()
    {
        _current = GetComponentInParent<Enemy>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlayerHealth player))
        {
            _current.TurnOnLaser();
        }
    }
}
