using UnityEngine;

public class WeaponEffectController : MonoBehaviour
{
    [SerializeField] private GameObject _zoneEffect;
    [SerializeField] private Transform _player;

    private GameObject _zone;

    private void OnEnable()
    {
        _zone = Instantiate(_zoneEffect, transform.position, Quaternion.identity, _player);
    }

    private void OnDisable()
    {
        Destroy(_zone);
    }
}