using System;
using _GAME.Common;
using RootMotion.FinalIK;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Action Die;

    [SerializeField] private EnemyAnimation _enemyAnimation;
    [SerializeField] private Transform _hitTarget;
    [SerializeField] private Ragdoll _ragdoll;
    [SerializeField] private AimIK _aim;
    
    [SerializeField] private bool _alive = true;
    
    public Transform HitTarget => _hitTarget;

    [ContextMenu("Die")]
    public void DieFast()
    {
        Die?.Invoke();
    }

    private void OnEnable()
    {
        Die += Dead;
    }

    private void OnDisable()
    {
        // throw new NotImplementedException();
    }

    private void Dead()
    {
        _aim.enabled = false;
        _alive = false;
        _ragdoll.ActivateRagdoll();
    }
}
