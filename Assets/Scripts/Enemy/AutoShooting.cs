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
        [SerializeField] private EnemiesTrigger _enemiesTrigger;
        
        [SerializeField] private AimController _aim;

        private void Start()
        {
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerHealth playerHealth))
            {
                Vector3 direction = (playerHealth.HitTarget.position - _shootPosition.position).normalized;
                
                Shoot(direction);
            }
        }

        // private void PreparationShoot()
        // {
        //     Debug.Log("hui2");
        //     RaycastHit hit;
        //     
        //     if (Physics.Raycast(_shootPosition.position, _shootPosition.TransformDirection(Vector3.forward), out hit, _distance, _targetLayerMask))
        //     {
        //         Debug.Log("hui3");
        //         Debug.DrawRay(_shootPosition.position, _shootPosition.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
        //         Vector3 direction = (hit.point - _shootPosition.position).normalized;
        //         
        //         Shoot(direction);
        //     }
        // }

        private void Shoot(Vector3 direction)
        {
            Debug.Log("hui");
            _muzzleFlare.Play(true);
            Bullet bullet = Instantiate(_bulletPrefab, _shootPosition.position, Quaternion.identity);
            bullet.Rigidbody.AddForce(direction * bullet.Speed, ForceMode.VelocityChange);
        }
    }
}