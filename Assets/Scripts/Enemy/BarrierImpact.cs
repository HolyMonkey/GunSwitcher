using System;
using UnityEngine;

public class BarrierImpact : MonoBehaviour
{
    [SerializeField] private Rigidbody[] _parts;
    [SerializeField] private Collider _mainCollider;

    private ZoneEffect _zoneEffect;
    
    [ContextMenu("Activate")]
    public void ActiveParts()
    {
        _mainCollider.enabled = false;
        
        foreach (var part in _parts)
        {
            part.constraints = RigidbodyConstraints.None;
        }

        _zoneEffect = GetComponentInChildren<ZoneEffect>();
        Destroy(_zoneEffect.gameObject);
    }

    [ContextMenu("Deactivate")]
    public void DeactiveParts()
    {
        _mainCollider.enabled = true;

        foreach (var part in _parts)
        {
            part.constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out PlayerHealth playerHealth))
        {
            playerHealth.TakeDamage(100);
        }
    }
}
