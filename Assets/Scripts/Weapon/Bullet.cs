using System;
using UnityEngine;

namespace Weapon
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private int _damage;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float speed;

        public Rigidbody Rigidbody => _rigidbody;

        public float Speed => speed;

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent(out Enemy enemy))
            {
                enemy.Die?.Invoke();
            }

            if (other.gameObject.TryGetComponent(out PlayerHealth playerHealth))
            {
                Debug.Log("shoot");
                playerHealth.TakeDamage(50);
            }
            
            Destroy(gameObject);
        }
    }
}