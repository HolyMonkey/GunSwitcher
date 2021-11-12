using System;
using System.Collections.Generic;
using System.Linq;
using Movement;
using RootMotion.FinalIK;
using Unity.Mathematics;
using UnityEngine;
using Weapon;


public class SwitchGun : MonoBehaviour
{
    [SerializeField] private List<WeaponChangerItem> _leftGuns;
    [SerializeField] private List<WeaponChangerItem> _rightGuns;
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private AimController _aim;
    [SerializeField] private LimbIK _secondHand;
    [SerializeField] private List<WeaponChangerItem> _guns;
    [SerializeField] private int _currentWeaponIndex;
    [SerializeField] private List<GameObject> _gunsTemplates;
    [SerializeField] private Transform _gunCreation;
    
    private WeaponChangerItem _gunTransform;

    public List<Weapon> Weapons => _weapons;

    private void Start()
    {
        _guns.AddRange(_leftGuns);
        _guns.AddRange(_rightGuns);
        
        PickCurrentWeapon();
        DrawIcons();
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
        // vector2.up 
        //  ?????????
        
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
            SetTransform(_leftGuns);
            
            _currentWeaponIndex--;
        }
        else
        {
            SetTransform(_rightGuns);
            
            _currentWeaponIndex++;
        }

        if (_currentWeaponIndex > _weapons.Count - 1)
        {
            _currentWeaponIndex = 0;
        }
        else if(_currentWeaponIndex < 0)
        {
            _currentWeaponIndex = _weapons.Count - 1;
        }
        
        GameObject animationGun = GetGunTemplate();
        Instantiate(animationGun, _gunTransform.gameObject.transform.position, animationGun.transform.rotation, _gunCreation);

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

        _aim.targetSwitchSmoothTime = _weapons[_currentWeaponIndex]._smoothTime;
        _secondHand.solver.target = _weapons[_currentWeaponIndex].HandPointWeapon.transform;
        
        DrawIcons();
    }
    
    private void DrawIcons()
    {
        int left = _currentWeaponIndex == 0 ? _weapons.Count - 1 : _currentWeaponIndex - 1;
        int right = _currentWeaponIndex == _weapons.Count -1 ? 0 : _currentWeaponIndex + 1;
        
        foreach (var gun in _guns)
        {
            gun.gameObject.SetActive(false);
        }

        WeaponChangerItem leftGun = _leftGuns.First(i => i.Id == _weapons[left].Id);
        WeaponChangerItem rightGun = _rightGuns.First(i => i.Id == _weapons[right].Id);

        leftGun.gameObject.SetActive(true);
        rightGun.gameObject.SetActive(true);
    }

    private void SetTransform(List<WeaponChangerItem> guns)
    {
        foreach (var gun in guns)
        {
            _gunTransform = guns.FirstOrDefault(gun => gun.gameObject.activeSelf == true);
        }
    }

    private GameObject GetGunTemplate()
    {
        foreach (var gunTemplate in _gunsTemplates)
        {
            if (gunTemplate.gameObject.GetComponent<WeaponChangerItem>().Id == _weapons[_currentWeaponIndex].Id)
            {
                return gunTemplate;
            }
        }

        return null;
    }

    [Serializable]
    public class Weapon
    {
        public string Name;
        public Weapons Id;
        public GameObject WeaponModel;
        public GameObject HandPointWeapon;
        public float _smoothTime;
        public Sprite Icon;
    }
}
