using System;
using System.Collections.Generic;
using Enemies;
using UnityEngine;

namespace Movement
{
    public class TargetsFinder : MonoBehaviour
    {
        public Action<List<Enemy>> EnemisFinded;

        [SerializeField] private List<Enemy> _targets;

        public List<Enemy> Targets => _targets; // to refactor
        
        private void OnTriggerEnter(Collider other)
        {
            
            if (TryGetComponent(out Enemy enemy) == true)
            {
                _targets.Add(enemy);
                enemy.Die += () => OnEnemyDied(enemy);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (TryGetComponent(out Enemy enemy) == true)
            {
                _targets.Remove(enemy);
            }
        }
        
        private void OnEnemyDied(Enemy enemy)
        {
            _targets.Remove(enemy);
        }
    }
}