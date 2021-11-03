using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightHealth : MonoBehaviour
{
    public Action<int> Damaged;

    [SerializeField] private bool _isPlayer;
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private Animator _animator;
    [SerializeField] private int _health;

    public int Health => _health;

    public void TakeDamage(int damage)
    {
        _health -= damage;
        
        Damaged?.Invoke(_health);
        TryDie();
    }

    private void TryDie()
    {
        if (_health <= 0)
        {
            if (_isPlayer == true)
            {
                _playerHealth.TakeDamage(10000);
            }
            else
            {
                _animator.SetBool("Die", true);
            }
        }
    }
}
