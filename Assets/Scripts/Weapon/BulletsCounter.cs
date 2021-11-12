using UnityEngine;

public abstract class BulletsCounter : MonoBehaviour
{
    [SerializeField] private BulletCounterUI _bulletCounterUI;
    
    [SerializeField] protected int BulletCount;
    
    private void Awake()
    {
        _bulletCounterUI = FindObjectOfType<BulletCounterUI>();
    }

    protected void ChangeBulletCount()
    {
        _bulletCounterUI.SetBulletsCounter(BulletCount);
    }
    
    protected void ChangeBulletCount(char symbol)
    {
        _bulletCounterUI.SetBulletsCounter(symbol);
    }
}
