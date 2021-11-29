using System;
using System.Collections;
using System.Collections.Generic;
using Movement;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlyerTurner : MonoBehaviour
{
    private PhysicsMovement _movement;

    private void Start()
    {
        _movement = GetComponent<PhysicsMovement>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Turn>(out Turn turn))
        {
            _movement.ChangeDirection(turn.Direction, turn.Rotation);
        }
    }
}
