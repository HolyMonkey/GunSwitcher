using System;
using _GAME.Common;
using Movement;
using RootMotion.FinalIK;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Action Die;

    [SerializeField] private EnemyAnimation _enemyAnimation;
    [SerializeField] private Transform _hitTarget;
    [SerializeField] private Ragdoll _ragdoll;
    [SerializeField] private AimIK _aim;
    [SerializeField] private GameObject _laser;
    [SerializeField] private AutoShooting _autoShooting;
    [SerializeField] private Collider _weaponTrigger;
    [SerializeField] private bool _alive = true;
    
    private EnemiesTrigger _enemiesTrigger;
    private ZoneEffect _zoneEffect;
    
    public Transform HitTarget => _hitTarget;

    [ContextMenu("Die")]
    public void DieFast()
    {
        Die?.Invoke();
    }

    private void Awake()
    {
        _enemiesTrigger = GetComponentInParent<EnemiesTrigger>();
    }

    private void OnEnable()
    {
        _laser.SetActive(false);
        _enemiesTrigger.TargetFinded += OnPlayerFinded;
        Die += Dead;
    }

    private void OnDisable()
    {
        _enemiesTrigger.TargetFinded += OnPlayerFinded;
        Die -= Dead;
    }

    private void Dead()
    {
        _zoneEffect = GetComponentInChildren<ZoneEffect>();
        Destroy(_zoneEffect.gameObject);
        
        _weaponTrigger.enabled = false;
        _aim.enabled = false;
        _alive = false;
        _laser.SetActive(false);
        _autoShooting.enabled = false;
        _ragdoll.ActivateRagdoll();
    }

    private void OnPlayerFinded()
    {
        if (_alive)
        {
            _laser.SetActive(true);
        }
    }
}
