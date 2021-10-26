using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private bool _isAlive => _health > 0;
    
    public void TakeDamage(float damage)
    {
        _health -= damage;
        TryDie();
    }

    private void TryDie()
    {
        if (_isAlive == false)
        {
            
        }
    }
}
