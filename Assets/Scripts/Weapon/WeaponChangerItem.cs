using System;
using UnityEngine;

namespace Weapon
{
    public class WeaponChangerItem : MonoBehaviour
    {
        [SerializeField] private Weapons _id;
        [SerializeField] private GameObject _zoneEffect;
        [SerializeField] private Transform _effectParent;

        private GameObject _zone;
        
        public Weapons Id => _id;

        private void OnEnable()
        {
            _zone = Instantiate(_zoneEffect, transform.position, Quaternion.identity, _effectParent);
        }

        private void OnDisable()
        {
            Destroy(_zone);
        }
    }
}