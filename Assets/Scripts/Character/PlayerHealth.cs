using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float _health;

    public void TakeDamage(float damage)
    {
        _health -= damage;
        TryDie();
    }

    private void TryDie()
    {
        if (_health <= 0)
        {
            
        }
    }
}
