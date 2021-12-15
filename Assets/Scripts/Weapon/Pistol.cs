using System.Collections;
using System.Linq;
using Movement;
using RootMotion.FinalIK;
using UnityEngine;

namespace Weapon
{
    public class Pistol : BulletsCounter
    {
        [SerializeField] private int _distance;
        [SerializeField] private float _shootDelay = 0.5f;
        [SerializeField] private LayerMask _targetLayerMask;
        
        [SerializeField] private ParticleSystem _muzzleFlare;
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private Transform _shootPosition;

        [SerializeField] private AimController _aimController;
        [SerializeField] private TargetsFinder _finder;
        [SerializeField] private ParticleSystem _sleeve;

        private Enemy _currentTarget;
        private Coroutine _shooting;

        private void OnEnable()
        {
            PickTarget();

            _finder.EnemyFinded += OnTargetFinded;
            _finder.NotEnoughTargets += OnNotEnoughTargets;
        }

        private void OnDisable()
        {
            _shooting = null;
            _finder.EnemyFinded -= OnTargetFinded;
            _finder.NotEnoughTargets -= OnNotEnoughTargets;
            
            _shooting = null;
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
                _sleeve.transform.position = _shootPosition.transform.position;
                _sleeve.Play(true);
                _muzzleFlare.Play(true);
                Bullet bullet = Instantiate(_bulletPrefab, _shootPosition.position, transform.rotation);
                bullet.Rigidbody.AddForce(direction * bullet.Speed, ForceMode.VelocityChange);

                if (BulletCount > 80)
                {
                }
                else
                {
                    BulletCount--;

                    if (Swith != null)
                    {
                        Swith.AddBulletCount(gameObject, BulletCount);
                    }
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
        }

        private void OnNotEnoughTargets()
        {
            _currentTarget = null;
            _aimController.target = null;
            _aimController.weight = 0;
        }

        private void PickTarget()
        {
            if (enabled == false)
            {
                return;
            }
            
            if (_finder.Targets.Count > 0)
            {
                _currentTarget = _finder.Targets.FirstOrDefault(t => t.enabled = true);
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

        public void OffShooting()
        {
            _shooting = null;
        }
    }
}