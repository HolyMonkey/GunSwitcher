using UnityEngine;

public class RestartPanel : MonoBehaviour
{
    public void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
        Time.timeScale = 1;
    }
}
