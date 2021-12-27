using System;
using System.Collections;
using UnityEngine;

public class FightHealth : MonoBehaviour
{
    public Action<int> Damaged;

    [SerializeField] private bool _isPlayer;
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private Animator _animator;
    [SerializeField] private int _health;
    [SerializeField] private GameObject _victoryPanel;
    [SerializeField] private GameObject _fightCanvas;
    [SerializeField] private GameObject _victoryConfetty;
    [SerializeField] private Transform _confettyPosition;

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
            if (_isPlayer)
            {
                _playerHealth.TakeDamage(10000);
            }
            else
            {
                _animator.SetBool("Die", true);
                StartCoroutine("WaitForLevelEnd");
            }
        }
    }

    private IEnumerator WaitForLevelEnd()
    {
        _fightCanvas.SetActive(false);
        Instantiate(_victoryConfetty, _confettyPosition.transform.position, _victoryConfetty.transform.rotation);
        
        yield return new WaitForSeconds(1f);
        
        _victoryPanel.SetActive(true);
    }
}
