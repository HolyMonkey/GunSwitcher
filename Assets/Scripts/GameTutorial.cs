using Movement;
using UnityEngine;

public class GameTutorial : MonoBehaviour
{
  [SerializeField] private GameObject _tapTutorialUi;
  [SerializeField] private Player _player;
  [SerializeField] private PhysicsMovement _movement;

  private bool isStopped;

  private void Update()
  {
    if (isStopped)
    {
      
#if UNITY_ANDROID
      
      if (Input.touchCount > 0)
      {
        ContinueMove();
      }
      
#endif
      if (Input.GetMouseButtonDown(0))
      {
        ContinueMove();
      }
    }
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.TryGetComponent(out PlayerHealth player))
    {
      StopMove();
    }
  }

  private void StopMove()
  {
    isStopped = true;
    _tapTutorialUi.SetActive(true);
    _player.PauseAnimation();
    _movement.PickState(MovingState.Stop);
  }

  private void ContinueMove()
  {
    isStopped = false;
    _tapTutorialUi.SetActive(false);
    _player.PlayAnimation();
    _movement.PickState(MovingState.MoveNormal);
  }
}
