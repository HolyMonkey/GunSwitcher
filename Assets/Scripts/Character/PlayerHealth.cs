using System;
using Movement;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public Action Die;
    
    [SerializeField] private float _health;
    [SerializeField] private Transform _hitTarget;

    [SerializeField] private PhysicsMovement _physicsMovement;
    [SerializeField] private bool _damageAvailability = true;
    [SerializeField] private GameObject _endGamePanel;
    [SerializeField] private GameObject _fightCanvas;

    private bool _isAlive => _health > 0;
    
    public Transform HitTarget => _hitTarget;

    public void TakeDamage(float damage)
    {
        if(_damageAvailability == false) return;
        _damageAvailability = false;
        DelayedCallUtil.DelayedCall(1.5f, () => {_damageAvailability = true;});
        
        _physicsMovement.PickState(MovingState.MoveWounded);
        
        _health -= damage;
        TryDie();
    }

    private void TryDie()
    {
        if (_isAlive == false)
        {
            _endGamePanel.gameObject.SetActive(true);
            _physicsMovement.PickState(MovingState.Stop);
            _fightCanvas.SetActive(false);
            Die?.Invoke();
        }
    }
}
