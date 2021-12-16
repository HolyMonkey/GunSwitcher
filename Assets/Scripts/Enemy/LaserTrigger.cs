using UnityEngine;

public class LaserTrigger : MonoBehaviour
{
    private Enemy[] _enemies;

    private void Start()
    {
        _enemies = GetComponentsInChildren<Enemy>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlayerHealth player))
        {
            foreach (var enemy in _enemies)
            {
                enemy.TurnOnLaser();
            }
        }
    }
}
