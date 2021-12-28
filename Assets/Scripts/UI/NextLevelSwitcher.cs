using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelSwitcher : MonoBehaviour
{
   [SerializeField] private int _currentLevel;
   
   private int _maxLevel = 10;

   private void Awake()
   {
      Debug.Log(PlayerPrefs.GetInt("level"));
      
      if (_currentLevel != PlayerPrefs.GetInt("level"))
      {
         SceneManager.LoadScene(PlayerPrefs.GetInt("level"));
      }
   }

   private void Start()
   {
      PlayerPrefs.SetInt("level", _currentLevel);
   }

   public void ContinueLevel()
   {
      if (_currentLevel + 1 >= _maxLevel)
      {
         _currentLevel = 0;
      }
      else
      {
         _currentLevel++;
      }

      PlayerPrefs.SetInt("level", _currentLevel);
      SceneManager.LoadScene(_currentLevel);
   }
}
