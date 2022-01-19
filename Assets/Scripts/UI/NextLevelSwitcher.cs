using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelSwitcher : MonoBehaviour
{
   [SerializeField] private int _currentLevel;
   [SerializeField] private TMP_Text _currentLevelCounter;
   [SerializeField] private TMP_Text _nextLevelCouner;

   private int _currentLevelCount = 1;
   private int _nextLevelCount => _currentLevelCount + 1;
   private int _maxLevel = 10;

   private void Awake()
   {
      if (PlayerPrefs.GetInt("levelCount") == 0)
      {
         _currentLevelCount = 1;
      }
      else
      {
         _currentLevelCount = PlayerPrefs.GetInt("levelCount");
      }

      _currentLevelCounter.text = _currentLevelCount.ToString();
      _nextLevelCouner.text = _nextLevelCount.ToString();
      
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
         _currentLevel = 4;
      }
      else
      {
         _currentLevel++;
      }

      _currentLevelCount++;

      PlayerPrefs.SetInt("level", _currentLevel);
      PlayerPrefs.SetInt("levelCount", _currentLevelCount);
      SceneManager.LoadScene(_currentLevel);
   }
}
