using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Weapon;

public abstract class BulletsCounter : MonoBehaviour
{
    [SerializeField] private BulletCounterUI _bulletCounterUI;
    [SerializeField] protected int BulletCount;
    [SerializeField] protected SwitchGun Swith;

    private void Awake()
    {
        _bulletCounterUI = FindObjectOfType<BulletCounterUI>();
    }

    private void OnDisable()
    {
        if (Swith != null)
        {
            Swith.AddBulletCount(gameObject, BulletCount);
        }
    }

    protected void ChangeBulletCount()
    {
        _bulletCounterUI.SetBulletsCounter(BulletCount);
    }
    
    protected void ChangeBulletCount(char symbol)
    {
        _bulletCounterUI.SetBulletsCounter(symbol);
    }
}
