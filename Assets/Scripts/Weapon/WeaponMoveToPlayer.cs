using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMoveToPlayer : MonoBehaviour
{
    [SerializeField] private PlayerHand _righthand;
    private float _speed = 6f;
    
    private void Awake()
    {
        _righthand = FindObjectOfType<PlayerHand>();
        Destroy(gameObject, 0.4f);
    }

    private void Update()
    {
        transform.position =
            Vector3.MoveTowards(transform.position, _righthand.transform.position, _speed * Time.deltaTime);
    }
}
