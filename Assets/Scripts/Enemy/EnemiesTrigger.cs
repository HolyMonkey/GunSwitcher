using System;
using RootMotion.FinalIK;
using UnityEngine;
using UnityEngine.Events;

namespace _GAME.Common
{
    public class EnemiesTrigger : MonoBehaviour
    {
        [SerializeField] private AimController[] _aims;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerHealth playerHealth))
            {
                foreach (var aim in _aims)
                {
                    aim.target = playerHealth.transform;
                }
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