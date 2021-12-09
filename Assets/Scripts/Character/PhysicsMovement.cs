using System;
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
        [SerializeField] private float _normalSpeed = 5f;
        [SerializeField] private GameObject _gunSwitcher;
        [SerializeField] private float _rotationSpeed;

        private Vector3 _direction;
        private Vector3[] _directions;
        private int _counter;
        private Quaternion _targetRotation;

        private void Start()
        {
            _counter = 0;
            _directions = new [] {new Vector3(0,0,-1), new Vector3(1,0,0), new Vector3(0,0,1), new Vector3(-1,0,0)};
            _direction = _directions[_counter];
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
        }
        
        private void OnGameStart()
        {
            _gunSwitcher.SetActive(true);
            PickState(MovingState.MoveNormal);
        }

        private void Move(Vector3 direction)
        {
            Vector3 offset = direction * _speed;
            _rigidbody.MovePosition(_rigidbody.position + offset * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, _targetRotation, Time.deltaTime * _rotationSpeed);
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
                    _speed = _normalSpeed;
                    break;
                case MovingState.MoveNormal:
                    _speed = _normalSpeed;
                    break;
            }
        }

        public void ChangeDirection(bool isTurnedLeft)
        {
            if (isTurnedLeft)
            {
                if (_counter + 1 < _directions.Length)
                {
                    _counter++;
                }
                else
                {
                    _counter = 0;
                }
                
                _targetRotation = transform.rotation * Quaternion.Euler(0, -90, 0);
            }
            else
            {
                if (_counter - 1 >= 0)
                {
                    _counter--;
                }
                else
                {
                    _counter = _directions.Length - 1;
                }
                
                _targetRotation = transform.rotation * Quaternion.Euler(0, 90, 0);
            }

            _direction = _directions[_counter];
        }
    }
}
