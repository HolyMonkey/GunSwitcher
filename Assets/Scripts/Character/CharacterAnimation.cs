using System;
using Movement;
using UnityEngine;

[Serializable]
public struct AnimationStates
{
    public const string Run = nameof(Run);
    public const string Fight = nameof(Fight);
    public const string Wounded = nameof(Wounded);
    public const string Die = nameof(Die);
}

public class CharacterAnimation : MonoBehaviour
{
    [SerializeField] private PhysicsMovement _movement;
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerHealth _health;
    
    private void OnEnable()
    {
        _movement.StateUpdated += OnMovingStateUpdated;
        _health.Die += OnDie;
    }

    private void OnDisable()
    {
        _movement.StateUpdated -= OnMovingStateUpdated;
    }

    public void PickState(string stateName, bool stateValue)
    {
        _animator.SetBool(stateName, stateValue);
    }

    private void OnDie()
    {
        PickState(AnimationStates.Die, true);
    }
    
    private void OnMovingStateUpdated(MovingState movingState)
    {
        switch (movingState)
        {
            case MovingState.Stop:
                PickState(AnimationStates.Run, false);
                PickState(AnimationStates.Wounded, false);
                break;
            case MovingState.MoveNormal:
                PickState(AnimationStates.Run, true);
                PickState(AnimationStates.Wounded, false);
                break;
            case MovingState.MoveWounded:
                PickState(AnimationStates.Run, true);
                PickState(AnimationStates.Wounded, true);
                break;
        }
    }
}
