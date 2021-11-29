using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour
{
  [SerializeField] private bool _isTurnedLeft;
  
  private Vector3 _direction;
  private Quaternion _rotation;

  public Vector3 Direction => _direction;
  public Quaternion Rotation => _rotation;

  private void Start()
  {
    if (_isTurnedLeft)
    {
      _direction = Vector3.right;
      _rotation = Quaternion.Euler(0, 90, 0);
    }
    else
    {
      _direction = Vector3.left;
      _rotation = Quaternion.Euler(0, -90, 0);
    }
  }
}
