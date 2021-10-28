using System.Collections.Generic;
using Movement;
using UnityEngine;

namespace Levels
{
    public class EndLevelTrigger : MonoBehaviour
    {
        // [SerializeField] private LayerMask _playerLayer;

        private void OnTriggerEnter(Collider other)
        {
            // if (((1 << other.gameObject.layer) & _playerLayer) == 0) return;
            if (other.TryGetComponent(out PhysicsMovement physicsMovement))
            {
                physicsMovement.PickState(MovingState.Stop);
            }
            
        }
    }
}