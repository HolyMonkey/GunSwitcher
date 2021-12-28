using UnityEngine;

namespace Weapon
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float speed;
        [SerializeField] private ParticleSystem _hitEffect;

        public Rigidbody Rigidbody => _rigidbody;
        public float Speed => speed;

        private void Start()
        {
            Destroy(gameObject, 1f);
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent(out Enemy enemy))
            {
                if (_hitEffect != null)
                { 
                    Instantiate(_hitEffect, transform.position, Quaternion.identity);
                }

                enemy.Die?.Invoke();
                enemy.AddExplosionForce(transform.position);
            }

            if (other.gameObject.TryGetComponent(out PlayerHealth playerHealth))
            {
                if (_hitEffect != null)
                { 
                    Instantiate(_hitEffect, transform.position, Quaternion.identity);
                }
                
                playerHealth.TakeDamage(50);
            }
            
            Destroy(gameObject);
        }
    }
}