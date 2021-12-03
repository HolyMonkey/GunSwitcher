using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Weapon;

public abstract class BulletsCounter : MonoBehaviour
{
    [SerializeField] protected int BulletCount;
    [SerializeField] protected SwitchGun Swith;
    
    private void OnDisable()
    {
        if (Swith != null)
        {
            Swith.AddBulletCount(gameObject, BulletCount);
        }
    }
}
