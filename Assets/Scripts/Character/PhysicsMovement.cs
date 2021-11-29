using System;
using Unity.Mathematics;
using UnityEngine;

namespace Movement
{
    public class PhysicsMovement : MonoBehaviour
    {
        public Action<MovingState> StateUpdated;
        
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private MovingState _currentState;
        [SerializeField] private StartGame _startGameUi;
        [SerializeField] private float _speed;
        [SerializeField] private float _normalSpeed = 3f;
        [SerializeField] private float _woundedSpeed = 1.5f;
        [SerializeField] private GameObject _gunSwitcher;
        [SerializeField] private GameObject _bulletCounter;

        private Vector3 _direction;
        
        public bool IsMoving { get; private set; } = false;


        private void Start()
        {
            _direction = -Vector3.forward;
        }

        private void OnEnable()
        {
            _startGameUi.GameStarted += OnGameStart;
        }

        private void OnDisable()
        {
            _startGameUi.GameStarted += OnGameStart;
        }

        private void Update()
        {
            Move(_direction);
            IsMoving = true;
        }
        
        private void OnGameStart()
        {
            _bulletCounter.SetActive(true);
            _gunSwitcher.SetActive(true);
            PickState(MovingState.MoveNormal);
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

        public void ChangeDirection(Vector3 direction, Quaternion rotation)
        {
            _direction = direction;
            transform.rotation = rotation;
        }
    }
}
