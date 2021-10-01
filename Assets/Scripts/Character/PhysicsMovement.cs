using System;
using UnityEngine;

namespace Movement
{
    public class PhysicsMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;

        [SerializeField] private float _speed;

        public bool IsMoving { get; private set; } = false;

        private void Update()
        {
            Move(-Vector3.forward);
            IsMoving = true;
        }

        private void Move(Vector3 direction)
        {
            Vector3 offset = direction * _speed;
            IsMoving = true;
            _rigidbody.MovePosition(_rigidbody.position + offset * Time.deltaTime);
        }
    }
}
