using UnityEngine;
using UnityEngine.UI;

public class FightHealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private FightHealth _fightHealth;
    
    private void OnEnable()
    {
        _fightHealth.Damaged += UpdateSlider;
    }

    private void UpdateSlider(int health)
    {
        _slider.value = health;
    }
}
