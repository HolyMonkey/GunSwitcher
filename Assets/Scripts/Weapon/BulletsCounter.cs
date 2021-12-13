using System;
using UnityEngine;

public abstract class BulletsCounter : MonoBehaviour
{
    public int BulletCount;
    
    [SerializeField] protected SwitchGun Swith;

    private void OnDisable()
    {
        if (Swith != null)
        {
            Swith.AddBulletCount(gameObject, BulletCount);
        }
    }
}
