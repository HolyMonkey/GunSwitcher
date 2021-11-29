using UnityEngine;
using TMPro;

public class BulletCounterUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _bulletsCount;

    public void SetBulletsCounter(int bulletsCounter)
    {
        _bulletsCount.text = bulletsCounter.ToString();
    }
    
    public void SetBulletsCounter(char symbol)
    {
        _bulletsCount.text = symbol.ToString();
    }
}
