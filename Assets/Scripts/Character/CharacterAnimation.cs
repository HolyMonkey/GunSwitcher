using System;
using Movement;
using UnityEngine;

[Serializable]
public struct AnimationStates
{
    public const string Run = nameof(Run);
    public const string Finish = nameof(Finish);
    public const string Die = nameof(Die);
}

public class CharacterAnimation : MonoBehaviour
{
    [SerializeField] private PhysicsMovement _movement;
    [SerializeField] private Animator _animator;
    [SerializeField] private LevelProgress _levelProgress;
    
    private void FixedUpdate()
    {
        SetState(AnimationStates.Run, _movement.IsMoving);
        // _animator.SetBool(AnimationStates.Finish, _levelProgress.LevelComplete);
    }

    public void SetState(string stateName, bool stateValue)
    {
        _animator.SetBool(stateName, stateValue);
    }
}
