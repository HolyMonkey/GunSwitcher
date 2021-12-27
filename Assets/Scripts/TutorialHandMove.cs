using UnityEngine;

public class TutorialHandMove : MonoBehaviour
{
    [SerializeField] private Transform _pointA;
    [SerializeField] private Transform _pointB;
    [SerializeField] private float _speed;

    private Transform _target;

    private void Start()
    {
        _target = _pointA;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);

        if (transform.position == _pointB.position)
        {
            _target = _pointA;
        }
        else if (transform.position == _pointA.position)
        {
            _target = _pointB;
        }
    }
}
