using System;
using UnityEngine;

namespace Movement
{
    public class PhysicsMovement : MonoBehaviour
    {
        public Action<MovingState> StateUpdated;
        
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private MovingState _currentState;
        
        [SerializeField] private float _speed;
        [SerializeField] private float _normalSpeed = 3f;
        [SerializeField] private float _woundedSpeed = 1.5f;
            
        public bool IsMoving { get; private set; } = false;

        private void Start()
        {
            PickState(MovingState.MoveNormal);
        }

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

        public void PickState(MovingState movingState)
        {
            _currentState = movingState;
            StateUpdated?.Invoke(_currentState);

            switch (_currentState)
            {
                case MovingState.Stop:
                    _speed = 0;
                    break;
                case MovingState.MoveWounded:
                    _speed = _woundedSpeed;
                    break;
                case MovingState.MoveNormal:
                    _speed = _normalSpeed;
                    break;
            }
        }
    }
}
