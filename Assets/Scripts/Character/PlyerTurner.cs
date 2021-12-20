using Movement;
using UnityEngine;

public class PlyerTurner : MonoBehaviour
{
    [SerializeField] private GunfireController _gunfire;
    
    private PhysicsMovement _movement;

    private void Start()
    {
        _movement = FindObjectOfType<PhysicsMovement>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Turn turn))
        {
            _movement.ChangeDirection(turn.IsTurnedLeft);
            _gunfire.PrepareToShoot(true);
            
            Destroy(turn);
        }

        if (other.TryGetComponent<BeforeTurn>(out BeforeTurn beforeTurn))
        {
            _gunfire.PrepareToShoot(false);
        }
    }
}
