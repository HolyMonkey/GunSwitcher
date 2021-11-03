using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightHand : MonoBehaviour
{
    [SerializeField] private int _damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out FightHealth fightHealth))
        {
            fightHealth.TakeDamage(_damage);
        }
    }
}
