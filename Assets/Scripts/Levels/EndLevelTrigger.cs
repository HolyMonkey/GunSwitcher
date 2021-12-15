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
        [SerializeField] private FightImput _fightImput;
        [SerializeField] private ClampCharacterRotation _rotation;
        [SerializeField] private GameObject _bulletCountUi;
        [SerializeField] private GameObject _levelProgressUi;

            private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PhysicsMovement physicsMovement))
            {
                _rotation.enabled = false;
                physicsMovement.PickState(MovingState.Stop);
                _finishCanvas.SetActive(true);
                _playerCamera.enabled = false;
                _finishCamera.enabled = true;
                _gunSwicher.gameObject.SetActive(false);
                _player.position = _fightPoint.position;
                _animator.PickState(AnimationStates.Fight, true);
                _secondHand.enabled = false;
                _puncher.StartFighting();
                _fightImput.SetActiveScreen(true);
                _bulletCountUi.SetActive(false);
                _levelProgressUi.SetActive(false);
                _player.GetComponentInChildren<Player>().transform.rotation = _fightPoint.rotation;

                foreach (var weapon in _gunSwicher.Weapons)
                {
                    weapon.WeaponModel.SetActive(false);
                }
            }
        }
    }
}