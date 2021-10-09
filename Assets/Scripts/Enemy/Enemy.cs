using System;
using _GAME.Common;
using UnityEngine;

namespace Enemies
{
    public class Enemy : MonoBehaviour
    {
        public Action Die;

        [SerializeField] private CharacterAnimation _characterAnimation;
        [SerializeField] private Transform _hitTarget;
        [SerializeField] private Ragdoll _ragdoll;
        
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
            // _characterAnimation.SetState(AnimationStates.Die, true);
            _ragdoll.ActivateRagdoll();
        }
    }
}