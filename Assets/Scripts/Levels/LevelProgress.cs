using System;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgress : MonoBehaviour
{
    public Action LossLevel;

    [SerializeField] private Transform _startPosition;
    [SerializeField] private Transform _finishPosition;

    [SerializeField] private Transform _characterPosition;

    [SerializeField] private Slider _levelSlider;

    private float _levelDistance;
    private bool _levelComplete = false;
    private bool _levelLoss = false;

    public bool LevelComplete => _levelComplete;
    public bool LevelLoss => _levelLoss;

    private void OnEnable()
    {
        LossLevel += OnLevelLoss;
    }

    private void OnDisable()
    {
        LossLevel -= OnLevelLoss;
    }

    private void Start()
    {
        _levelDistance = Vector3.Distance(_startPosition.position, _finishPosition.position);
        _levelSlider.maxValue = _levelDistance;
    }

    private void Update()
    {
        if (_levelComplete == false)
        {
            _levelSlider.value =
                _levelDistance - Vector3.Distance(_characterPosition.position, _finishPosition.position);

            if (Vector3.Distance(_characterPosition.position, _startPosition.position) >= _levelDistance)
            {
                _levelSlider.value = _levelDistance;
                DelayedCallUtil.DelayedCall(1.5f, () => _levelComplete = true);
            }
        }
    }

    private void OnLevelLoss()
    {
        _levelLoss = true;
    }

}
