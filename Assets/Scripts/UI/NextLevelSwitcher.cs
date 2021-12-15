using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelSwitcher : MonoBehaviour
{
   [SerializeField] private int _currentLevel;
   
   private int _maxLevel = 10;

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

      SceneManager.LoadScene(_currentLevel);
   }
}
