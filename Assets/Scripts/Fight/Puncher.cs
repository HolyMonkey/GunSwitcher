using UnityEngine;

public class Puncher : MonoBehaviour
{
    private Animator _animator;

    private const string Attack = "Attack";
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void StartFighting()
    {
        _animator.SetBool(Attack, true);
    }
}
