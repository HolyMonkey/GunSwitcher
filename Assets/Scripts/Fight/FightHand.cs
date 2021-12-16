using UnityEngine;

public class FightHand : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private GameObject _hitEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Puncher puncher))
        {
            var effect = Instantiate(_hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1f);
        }
        
        if (other.TryGetComponent(out FightHealth fightHealth))
        {
            var effect = Instantiate(_hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1f);
            
            fightHealth.TakeDamage(_damage);
        }
    }
}
