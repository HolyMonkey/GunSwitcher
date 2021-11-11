using System.Collections;
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
        StartCoroutine(WaitForStartFighting());
    }

    private IEnumerator WaitForStartFighting()
    {
        yield return new WaitForSeconds(1.7f);
        _animator.SetBool(Attack, true);
    }
}
