using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomateShells : MonoBehaviour
{
    [SerializeField] private List<GameObject> _shells;
    [SerializeField] private SwitchGun _switchGun;

    private int _bulletCount;
    
    private void OnEnable()
    {
        _bulletCount = _switchGun._assaultBulCount / 2;
        _switchGun.OnAssaultBulletChanged += OnBulletCountChanged;
        DrawShells();
    }

    private void OnDisable()
    {
        _switchGun.OnAssaultBulletChanged -= OnBulletCountChanged;
        DeactivateShells();
    }
    
    private void OnBulletCountChanged(int count)
    {
        _bulletCount = count / 2;
        DrawShells();
    }

    private void DrawShells()
    {
        if (_bulletCount > _shells.Count)
        {
            _bulletCount = _shells.Count;
        }
        
        for (int i = 0; i < _shells.Count; i++)
        {
            if (_bulletCount > i)
            {
                _shells[i].gameObject.SetActive(true);
            }
            else
            {
                _shells[i].gameObject.SetActive(false);
            }
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
