using System;
using System.Collections.Generic;
using UnityEngine;

namespace Movement
{
    public class TargetsFinder : MonoBehaviour
    {
        public Action<Enemy> EnemyFinded;
        public Action NotEnoughTargets;

        [SerializeField] private Collider _trigger;
        
        [SerializeField] private LayerMask _enemyLayer;
        [SerializeField] private List<Enemy> _targets;

        public List<Enemy> Targets => _targets; // to refactor
        
        private void OnTriggerEnter(Collider other)
        {
            if (((1 << other.gameObject.layer) & _enemyLayer) == 0) return;

            Enemy enemy = other.GetComponent<Enemy>();
            
            _targets.Add(enemy);
            enemy.Die += () => OnEnemyDied(enemy);
            EnemyFinded?.Invoke(enemy);
        }

        private void OnTriggerExit(Collider other)
        {
            if (((1 << other.gameObject.layer) & _enemyLayer) == 0) return;

            Enemy enemy = other.GetComponent<Enemy>();
            _targets.Remove(enemy);

            if (_targets.Count == 0)
            {
                NotEnoughTargets?.Invoke();
            }
        }

        public void UpdateTrigger()
        {
            _trigger.enabled = false;
            _trigger.enabled = true;
        }
        
        private void OnEnemyDied(Enemy enemy)
        {
            _targets.Remove(enemy);
        }
    }
}