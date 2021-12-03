using _GAME.Common;
using UnityEngine;

public class FightImput : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteTapCatcher _catcher;

    private void OnEnable()
    {
        _catcher.OnClick += Punch;
    }

    private void Punch()
    {
        _animator.SetTrigger("Punch");
    }

    public void SetActiveScreen(bool isActive)
    {
        _catcher.gameObject.SetActive(isActive);
    }
}
