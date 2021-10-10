using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SwitchGun : MonoBehaviour
{
    [SerializeField] private Image _leftGun;
    [SerializeField] private Image _rightGun;
    [SerializeField] private List<Weapon> _weapons;

    [SerializeField] private int _currentWeaponIndex;
    
    [Serializable]
    public class Weapon
    {
        public string Name;
        public Sprite Icon;
    }
}
