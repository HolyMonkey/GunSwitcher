using System;
using System.Collections;
using Movement;
using RootMotion.FinalIK;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Events;

namespace Weapon
{
    public class Pistol : BulletsCounter
    {
        [SerializeField] private int _distance;
        [SerializeField] private float _shootDelay = 0.5f;
        [SerializeField] private bool _shootReady = true;
        [SerializeField] private LayerMask _targetLayerMask;
        
        [SerializeField] private ParticleSystem _muzzleFlare;
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private Transform _shootPosition;

        [SerializeField] private AimController _aimController;
        [SerializeField] private TargetsFinder _finder;
        [SerializeField] private char _infinitySymbol;

        private Enemy _currentTarget;
        private Coroutine _shooting;

        private void OnEnable()
        {
            _finder.EnemyFinded += OnTargetFinded;
            _finder.NotEnoughTargets += OnNotEnoughTargets;

            if (BulletCount > 50)
            {
                ChangeBulletCount(_infinitySymbol);
            }
            else
            {
                ChangeBulletCount();
            }
        }

        private void OnDisable()
        {
            _finder.EnemyFinded -= OnTargetFinded;
            _finder.NotEnoughTargets -= OnNotEnoughTargets;
        }

        private void OnTargetFinded(Enemy enemy)
        {
            enemy.Die += () => OnEnemyDie(enemy);
            
            if (_currentTarget == null)
            {
                PickTarget();
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
            if (BulletCount > 0)
            {
                _muzzleFlare.Play(true);
                Bullet bullet = Instantiate(_bulletPrefab, _shootPosition.position, Quaternion.identity);
                bullet.Rigidbody.AddForce(direction * bullet.Speed, ForceMode.VelocityChange);
                
                if (BulletCount > 50)
                {
                    ChangeBulletCount(_infinitySymbol);
                }
                else
                {
                    BulletCount--;
                    ChangeBulletCount();
                }
            }
        }

        private IEnumerator Shooting()
        {
            while (_currentTarget != null)
            {
                PreparationShoot();
                yield return new WaitForSeconds(_shootDelay);
            }
        }
        
        private void OnEnemyDie(Enemy enemy)
        {
            if (_shooting != null)
            {
                StopCoroutine(_shooting);
                _shooting = null;
            }

            PickTarget();
            
            // if (enemy == _currentTarget)
            // {
            //     PickTarget();
            // }
        }

        private void OnNotEnoughTargets()
        {
            _aimController.target = null;
            _aimController.weight = 0;
        }

        private void PickTarget()
        {
            if (_finder.Targets.Count > 0)
            {
                _currentTarget = _finder.Targets[0];
                _aimController.target = _currentTarget.HitTarget;
                _aimController.weight = 1;
            }
            else
            {
                _currentTarget = null;
                _aimController.target = null;
                _aimController.weight = 0;
            }
            
            if (_currentTarget != null)
            {
                if (_shooting == null)
                {
                    _shooting = StartCoroutine(Shooting());
                }
            }
        }
    }
}