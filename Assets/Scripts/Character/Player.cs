using UnityEngine;

public class Player : MonoBehaviour
{
    private float prevSpeed;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void PauseAnimation()
    {
        prevSpeed = _animator.speed;
        _animator.speed = 0;
    }

    public void PlayAnimation()
    {
        _animator.speed = prevSpeed;
    }
}
