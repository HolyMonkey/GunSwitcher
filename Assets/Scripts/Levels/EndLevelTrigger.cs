using System.Collections.Generic;
using Cinemachine;
using Movement;
using RootMotion.Demos;
using UnityEngine;

namespace Levels
{
    public class EndLevelTrigger : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCameraBase _finishCamera;
        [SerializeField] private CinemachineVirtualCameraBase _playerCamera;
        [SerializeField] private SwitchGun _gunSwicher;
        [SerializeField] private Transform _player;
        [SerializeField] private Transform _fightPoint;
        [SerializeField] private CharacterAnimation _animator;
        [SerializeField] private SecondHandOnGun _secondHand;
        [SerializeField] private Puncher _puncher;
        [SerializeField] private GameObject _finishCanvas;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PhysicsMovement physicsMovement))
            {
                physicsMovement.PickState(MovingState.Stop);
                _finishCanvas.SetActive(true);
                _playerCamera.enabled = false;
                _finishCamera.enabled = true;
                _gunSwicher.gameObject.SetActive(false);
                _player.position = _fightPoint.position;
                //_player.rotation = _fightPoint.rotation;
                _animator.PickState(AnimationStates.Fight, true);
                _secondHand.enabled = false;
                _puncher.StartFighting();

                foreach (var weapon in _gunSwicher.Weapons)
                {
                    weapon.WeaponModel.SetActive(false);
                }
            }
        }
    }
}