using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticle : MonoBehaviour
{
    [SerializeField] private float _timeToDestroy;
    private void Start()
    {
        Destroy(gameObject, _timeToDestroy);
    }
}