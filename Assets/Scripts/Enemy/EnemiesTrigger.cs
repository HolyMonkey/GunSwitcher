using System;
using RootMotion.FinalIK;
using UnityEngine;

namespace _GAME.Common
{
    public class EnemiesTrigger : MonoBehaviour
    {
        public Action TargetFinded;
        
        [SerializeField] private AimController[] _aims;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerHealth playerHealth))
            {
                foreach (var aim in _aims)
                {
                    aim.target = playerHealth.transform;
                }
                
                TargetFinded?.Invoke();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out PlayerHealth playerHealth))
            {
                foreach (var aim in _aims)
                {
                    aim.target = null;
                }
            }
        }
    }
}