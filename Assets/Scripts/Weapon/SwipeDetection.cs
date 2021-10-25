using System;
using UnityEngine;

public class SwipeDetection : MonoBehaviour
{
    public static event OnSwipeInput SwipeEvent;
    public delegate void OnSwipeInput(Vector2 direction);

    private Vector2 _tapPosition;
    private Vector2 _swipeDelta;

    [SerializeField] private float _deadZone = 80;

    [SerializeField] private bool _isSwiping;
    [SerializeField] private bool _isMobile;

    private void Start()
    {
        _isMobile = Application.isMobilePlatform;
    }

    private void Update()
    {
        if (_isMobile == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                // Debug.Log("давн");
                _isSwiping = true;
                _tapPosition = Input.mousePosition;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                // Debug.Log("ап");
                ResetSwipe();
            }
        }
        else
        {
            if (Input.touchCount > 0)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    _isSwiping = true;
                    _tapPosition = Input.GetTouch(0).position;
                }
                else if (Input.GetTouch(0).phase == TouchPhase.Canceled || Input.GetTouch(0).phase == TouchPhase.Ended)
                {
                    ResetSwipe();
                }
            }
        }
        
        // Debug.Log(_isSwiping);
        CheckSwipe();
    }

    private void CheckSwipe()
    {
        // Debug.Log("CheckSwipe");
        
        _swipeDelta = Vector2.zero;

        Vector2 direction;
        
        if (_isSwiping)
        {
            if (_isMobile == false && Input.GetMouseButton(0))
            {
                _swipeDelta = (Vector2)Input.mousePosition - _tapPosition;
            }
            else if (Input.touchCount > 0)
            {
                _swipeDelta = Input.GetTouch(0).position - _tapPosition;
            }
        }

        if (_swipeDelta.magnitude > _deadZone)
        {
            if (SwipeEvent != null)
            {
                if (Mathf.Abs(_swipeDelta.x) > Mathf.Abs(_swipeDelta.y))
                {
                    direction = _swipeDelta.x > 0 ? Vector2.right : Vector2.left;
                }
                else
                {
                    direction = _swipeDelta.y > 0 ? Vector2.up : Vector2.down;
                }
                
                SwipeEvent?.Invoke(direction);
            }
            
            ResetSwipe();
        }
    }

    private void ResetSwipe()
    {
        _isSwiping = false;
        
        _tapPosition = Vector2.zero;
        _swipeDelta = Vector2.zero;
    }
}
