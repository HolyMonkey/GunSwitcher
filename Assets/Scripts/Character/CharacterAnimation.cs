using Movement;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    [SerializeField] private PhysicsMovement _movement;
    [SerializeField] private Animator _animator;
    [SerializeField] private LevelProgress _levelProgress;
    
    private void FixedUpdate()
    {
        _animator.SetBool(AnimationStates.Run, _movement.IsMoving);
        _animator.SetBool(AnimationStates.Finish, _levelProgress.LevelComplete);
    }
    
    private struct AnimationStates
    {
        public const string Run = nameof(Run);
        public const string Finish = nameof(Finish);
    }
}
