using System;
using System.Collections;
using Movement;
using RootMotion.FinalIK;
using UnityEngine;
using Weapon;

namespace _GAME.Common
{
    public class AutoShooting : MonoBehaviour
    {
        [SerializeField] private int _distance;
        [SerializeField] private float _shootDelay = 0.5f;
        [SerializeField] private LayerMask _targetLayerMask;
        
        [SerializeField] private ParticleSystem _muzzleFlare;
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private Transform _shootPosition;

        [SerializeField] private AimController _aim;

        private Coroutine _shooting;

        private void Update()
        {
            if (_aim.target != null)
            {
                PreparationShoot();
            }
        }

        private void PreparationShoot()
        {
            RaycastHit hit;
                if (Physics.Raycast(_shootPosition.position, _shootPosition.TransformDirection(Vector3.forward), out hit, _distance, _targetLayerMask))
                {
                    Debug.DrawRay(_shootPosition.position, _shootPosition.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                    
                        Vector3 direction = (hit.point - _shootPosition.position).normalized;
                        
                        Shoot(direction);
                }
        }

        private void Shoot(Vector3 direction)
        {
            _muzzleFlare.Play(true);
            Bullet bullet = Instantiate(_bulletPrefab, _shootPosition.position, Quaternion.identity);
            bullet.Rigidbody.AddForce(direction * bullet.Speed, ForceMode.VelocityChange);
        }
    }
}