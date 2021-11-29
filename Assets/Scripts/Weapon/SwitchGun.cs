using System;
using System.Collections.Generic;
using RootMotion.FinalIK;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Weapon;


public class SwitchGun : MonoBehaviour
{
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private AimController _aim;
    [SerializeField] private LimbIK _secondHand;
    [SerializeField] private List<GameObject> _gunsTemplates;
    [SerializeField] private Transform _gunCreation;

    [SerializeField] private List<WeaponChangerItem> _buttonGuns;

    [SerializeField] private Transform _leftGunTransform;
    [SerializeField] private Transform _rightGunTransform;
    [SerializeField] private Transform _topGunTransform;

    private Transform _gunTransform;
    private int _assaultBulCount;
    private int _rocketBulletsCount;
    
    private int _currentWeaponIndex;

    public List<Weapon> Weapons => _weapons;

    public event UnityAction<int> OnRocketBulletChanged;
    public event UnityAction<int> OnAssaultBulletChanged;

    private void Start()
    {
        _assaultBulCount = 20;
        _rocketBulletsCount = 3;
        OnAssaultBulletChanged?.Invoke(_assaultBulCount);
        OnRocketBulletChanged?.Invoke(_rocketBulletsCount);

        PickCurrentWeapon();

        foreach (var buttonGun in _buttonGuns)
        {
            buttonGun.GetComponent<Button>().enabled = false;
        }
    }

    public void ChangeWeapon(WeaponChangerItem weapon)
    {
        if (weapon.TryGetComponent(out Pistole pistole))
        {
            SetTransform(_topGunTransform);
            
            _currentWeaponIndex = 0;
        }
        else if (weapon.TryGetComponent(out AutomateShells automate))
        {
            SetTransform(_leftGunTransform);
            
            _currentWeaponIndex = 1;
        }
        else if (weapon.TryGetComponent(out RocketShells rocket))
        {
            SetTransform(_rightGunTransform);
            
            _currentWeaponIndex = 2;
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
        Instantiate(animationGun, _gunTransform.transform.position, animationGun.transform.rotation, _gunCreation);

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
        for (int i = 0; i < _buttonGuns.Count; i++)
        {
            if (i == _currentWeaponIndex)
            {
                DrawButtons(_buttonGuns[i],false, 0.5f);
            }
            else
            {
                DrawButtons(_buttonGuns[i],true);
            }
        }
    }

    private void DrawButtons(WeaponChangerItem buttonGun,bool enabledButton,  float alpha = 1f)
    {
        buttonGun.GetComponent<Button>().enabled = enabledButton;
        var color1 = buttonGun.GetComponentInChildren<Image>().color;
        color1.a = alpha;
        buttonGun.GetComponentInChildren<Image>().color = color1;
    }

    private void SetTransform(Transform gunTransform)
    {
        _gunTransform = gunTransform;
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

    public void AddBulletCount(GameObject gun, int count)
    {
        if (gun.TryGetComponent(out AssaultChecker automate))
        {
            _assaultBulCount = count;
            OnAssaultBulletChanged?.Invoke(_assaultBulCount);
        }
        else if (gun.TryGetComponent(out RocketChecker rocket))
        {
            _rocketBulletsCount = count;
            OnRocketBulletChanged?.Invoke(_rocketBulletsCount);
        }
    }

    [Serializable]
    public class Weapon
    {
        public Weapons Id;
        public GameObject WeaponModel;
        public GameObject HandPointWeapon;
        public float _smoothTime;
    }
}
