using System;
using System.Collections.Generic;
using UnityEngine;

namespace Movement
{
    public class TargetsFinder : MonoBehaviour
    {
        public Action<Enemy> EnemyFinded;
        public Action NotEnoughTargets;

        [SerializeField] private List<Enemy> _targets;

        public List<Enemy> Targets => _targets; // to refactor
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Enemy>(out Enemy enemy))
            {
                _targets.Add(enemy);
                enemy.Die += () => OnEnemyDied(enemy);
                EnemyFinded?.Invoke(enemy);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent<Enemy>(out Enemy enemy))
            {
                _targets.Remove(enemy);
            }

            if (_targets.Count == 0)
            {
                NotEnoughTargets?.Invoke();
            }
        }

        private void OnEnemyDied(Enemy enemy)
        {
            _targets.Remove(enemy);
        }
    }
}