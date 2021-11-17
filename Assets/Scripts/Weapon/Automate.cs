using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Automate : MonoBehaviour
{
    [SerializeField] private List<GameObject> _shells;
    [SerializeField] private SwitchGun _switchGun;

    private int _bulletCount;
    
    private void OnEnable()
    {
        _bulletCount = _switchGun.GetAssaultBulletCount();
        DrawShells();
    }

    private void OnDisable()
    {
        DeactivateShells();
    }

    private void DrawShells()
    {
        if (_bulletCount > _shells.Count)
        {
            return;
        }
        
        for (int i = 0; i < _bulletCount; i++)
        {
            _shells[i].gameObject.SetActive(true);
        }
    }

    private void DeactivateShells()
    {
        foreach (var shell in _shells)
        {
            shell.gameObject.SetActive(false);
        }
    }
}
