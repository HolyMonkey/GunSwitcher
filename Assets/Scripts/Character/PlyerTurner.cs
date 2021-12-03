using Movement;
using UnityEngine;

public class PlyerTurner : MonoBehaviour
{
    private PhysicsMovement _movement;
    [SerializeField] private GunfireController _gunfire;

    private void Start()
    {
        _movement = FindObjectOfType<PhysicsMovement>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Turn>(out Turn turn))
        {
            _movement.ChangeDirection(turn.Direction, turn.Rotation);
            _gunfire.PrepareToShoot(true);
        }

        if (other.TryGetComponent<BeforeTurn>(out BeforeTurn beforeTurn))
        {
            _gunfire.PrepareToShoot(false);
        }
    }
}
