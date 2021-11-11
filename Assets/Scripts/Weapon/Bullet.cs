using System;
using Unity.Mathematics;
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

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent(out Enemy enemy))
            {
                if (_hitEffect != null)
                { 
                    Instantiate(_hitEffect, transform.position, Quaternion.identity);
                }
                
                enemy.Die?.Invoke();
            }

            if (other.gameObject.TryGetComponent(out PlayerHealth playerHealth))
            {
                playerHealth.TakeDamage(50);
            }
            
            Destroy(gameObject);
        }
    }
}