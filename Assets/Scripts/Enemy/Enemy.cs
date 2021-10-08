using System;
using UnityEngine;

namespace Enemies
{
    public class Enemy : MonoBehaviour
    {
        public Action Die;
        public bool dead = false;
        
        [SerializeField] private CharacterAnimation _characterAnimation;
        [SerializeField] private Transform _hitTarget;

        public Transform HitTarget => _hitTarget;

        [ContextMenu("Die")]
        public void DieFast()
        {
            Die?.Invoke();
            // _characterAnimation.SetState(AnimationStates.Die, true);
        }

        private void OnEnable()
        {
            Die += Dead;
        }

        private void OnDisable()
        {
            // throw new NotImplementedException();
        }

        private void Dead()
        {
            _characterAnimation.SetState(AnimationStates.Die, true);
            dead = true;
        }
    }
}