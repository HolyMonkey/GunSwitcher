using System;
using System.Collections.Generic;
<<<<<<< HEAD
using System.Linq;
using Movement;
=======
>>>>>>> parent of bd48374 (Swithicng weapon)
using UnityEngine;
using UnityEngine.UI;
using Weapon;


public class SwitchGun : MonoBehaviour
{
    [SerializeField] private List<WeaponChangerItem> _leftGuns;
    [SerializeField] private List<WeaponChangerItem> _rightGuns;
    [SerializeField] private List<Weapon> _weapons;

<<<<<<< HEAD
    [SerializeField] private TargetsFinder _finder;

    [SerializeField] private List<WeaponChangerItem> _guns;
=======
    // [SerializeField] private SwipeDetection _swipeDetection;
>>>>>>> parent of bd48374 (Swithicng weapon)
    
    [SerializeField] private int _currentWeaponIndex;

    private void Start()
    {
<<<<<<< HEAD
        _guns.AddRange(_leftGuns);
        _guns.AddRange(_rightGuns);
        
        PickCurrentWeapon();
        DrawIcons();
=======
        Debug.Log(_weapons.Count);
>>>>>>> parent of bd48374 (Swithicng weapon)
    }

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
<<<<<<< HEAD

        PickCurrentWeapon();

        DrawIcons();
    }

    private void PickCurrentWeapon()
    {
        foreach (var weapon in _weapons)
        {
            weapon.WeaponModel.SetActive(false);
        }
        _weapons[_currentWeaponIndex].WeaponModel.SetActive(true);
        
        _finder.UpdateTrigger();
=======
        
        DrawIcons();
>>>>>>> parent of bd48374 (Swithicng weapon)
    }
    
    private void DrawIcons()
    {
        int left = _currentWeaponIndex == 0 ? _weapons.Count - 1 : _currentWeaponIndex - 1;
        int right = _currentWeaponIndex == _weapons.Count -1 ? 0 : _currentWeaponIndex + 1;

<<<<<<< HEAD
        foreach (var gun in _guns)
        {
            gun.gameObject.SetActive(false);
        }

        WeaponChangerItem leftGun = _leftGuns.First(i => i.Id == _weapons[left].Id);
        WeaponChangerItem rightGun = _rightGuns.First(i => i.Id == _weapons[right].Id);
=======
        Debug.Log($"Left {left}, Right {right}");
>>>>>>> parent of bd48374 (Swithicng weapon)
        
        leftGun.gameObject.SetActive(true);
        rightGun.gameObject.SetActive(true);
    }

    [Serializable]
    public class Weapon
    {
        public string Name;
<<<<<<< HEAD
        public Weapons Id;
        public GameObject WeaponModel;
=======
        public Sprite Icon;
>>>>>>> parent of bd48374 (Swithicng weapon)
    }
}
