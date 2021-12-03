using System;
using UnityEngine;

public class RestartPanel : MonoBehaviour
{
    [SerializeField] private FightImput _fightImput;


    private void OnEnable()
    {
        _fightImput.SetActiveScreen(false);
    }

    public void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
        Time.timeScale = 1;
    }
}
