using UnityEngine;

public class WeaponEffectController : MonoBehaviour
{
    [SerializeField] private GameObject _zoneEffect;
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _container;
    [SerializeField] private Vector3 _offset;

    private GameObject _zone;

    private void OnEnable()
    {
        _zone = Instantiate(_zoneEffect, _player.transform.position + _offset, Quaternion.identity, _container);
    }

    private void OnDisable()
    {
        Destroy(_zone);
    }
}