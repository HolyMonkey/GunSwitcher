using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    [SerializeField] private List<Button> _buttons;
    public event UnityAction GameStarted;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameStarted?.Invoke();

            for (int i = 0; i < _buttons.Count; i++)
            {
                if (i == 0)
                {
                    _buttons[i].enabled = false;
                }
                else
                {
                    _buttons[i].enabled = true;
                }
            }

            StartCoroutine("WaitUntilAnimationPlay");
        }
    }

    private IEnumerator WaitUntilAnimationPlay()
    {
        _animator.SetTrigger("OnButtonPressed");
        
        yield return new WaitForSeconds(0.5f);
        
        gameObject.SetActive(false);
    }
}
