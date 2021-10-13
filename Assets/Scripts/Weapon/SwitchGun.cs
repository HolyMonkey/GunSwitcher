using System;
using System.Collections.Generic;
using Movement;
using UnityEngine;
using UnityEngine.UI;


public class SwitchGun : MonoBehaviour
{
    [SerializeField] private Image _leftGun;
    [SerializeField] private Image _rightGun;
    [SerializeField] private List<Weapon> _weapons;

    [SerializeField] private TargetsFinder _finder;
    
    // [SerializeField] private SwipeDetection _swipeDetection;
    
    [SerializeField] private int _currentWeaponIndex;

    private void OnEnable()
    {
        SwipeDetection.SwipeEvent += OnSwipe;
    }

    private void OnDisable()
    {
        SwipeDetection.SwipeEvent -= OnSwipe;
    }

    private void OnSwipe(Vector2 direction)
    { 
        if(direction == Vector2.left)
        {
            ChangeWeapon(false);
        }
        else if (direction == Vector2.right)
        {
            ChangeWeapon(true);
        }
    }

    private void ChangeWeapon(bool isNext)
    {
        if (isNext)
        {
            _currentWeaponIndex++;
        }
        else
        {
            _currentWeaponIndex--;
        }

        if (_currentWeaponIndex > _weapons.Count - 1)
        {
            _currentWeaponIndex = 0;
        }
        else if(_currentWeaponIndex < 0)
        {
            _currentWeaponIndex = _weapons.Count - 1;
        }

        foreach (var weapon in _weapons)
        {
            weapon.WeaponModel.SetActive(false);
        }
        _weapons[_currentWeaponIndex].WeaponModel.SetActive(true);
        
        _finder.UpdateTrigger();
        
        DrawIcons();
    }

    private void DrawIcons()
    {
        int left = _currentWeaponIndex == 0 ? _weapons.Count - 1 : _currentWeaponIndex - 1;
        int right = _currentWeaponIndex == _weapons.Count -1 ? 0 : _currentWeaponIndex + 1;

        // Debug.Log($"Left {left}, Right {right}");
        
        _leftGun.sprite = _weapons[left].Icon;
        _rightGun.sprite = _weapons[right].Icon;
    }

    [Serializable]
    public class Weapon
    {
        public string Name;
        public Sprite Icon;
        public GameObject WeaponModel;
    }
}
