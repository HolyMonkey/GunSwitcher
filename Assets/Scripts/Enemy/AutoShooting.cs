using UnityEngine;
using Weapon;

namespace _GAME.Common
{
    public class AutoShooting : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _muzzleFlare;
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private Transform _shootPosition;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerHealth playerHealth))
            {
                Vector3 direction = (playerHealth.HitTarget.position - _shootPosition.position).normalized;
                
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