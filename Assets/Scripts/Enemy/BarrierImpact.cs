using System;
using UnityEngine;

public class BarrierImpact : MonoBehaviour
{
    [SerializeField] private Rigidbody[] _parts;
    [SerializeField] private Collider _mainCollider;

    [ContextMenu("Activate")]
    public void ActiveParts()
    {
        _mainCollider.enabled = false;
        
        foreach (var part in _parts)
        {
            part.constraints = RigidbodyConstraints.None;
            part.GetComponent<Collider>().isTrigger = true;
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
