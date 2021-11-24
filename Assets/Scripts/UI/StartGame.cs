using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    [SerializeField] private GameObject _swipe;
    [SerializeField] private List<Button> _buttons;
    public event UnityAction GameStarted;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _swipe.SetActive(true);
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
            
            gameObject.SetActive(false);
        }
    }
}
