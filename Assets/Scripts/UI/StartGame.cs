using System;
using UnityEngine;
using UnityEngine.Events;

public class StartGame : MonoBehaviour
{
    [SerializeField] private GameObject _swipe;
    public event UnityAction GameStarted;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _swipe.SetActive(true);
            GameStarted?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
