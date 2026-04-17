using System;
 
using UnityEngine;
using UnityEngine.Events;

public class Rail : MonoBehaviour
{
    [SerializeField] double _speed = 0.25f;
    [SerializeField] float _offset = 0f;
    [SerializeField] LevelSpline _level;
    [SerializeField] UnityEvent OnLevelUIncremented;
    [SerializeField] bool _move=true, _rotate=true;

    private float _lastFrameU;

    private Quaternion _endRotation = Quaternion.identity;

    private double _lastFrameTime=0;

    private bool _paused = false;
    public float CurrentLevelU => Time.time * (float)_speed+_offset;
    private void Update()
    {
        if (_paused) return;
        if(_move)
        UpdatePosition();
        if(_rotate)
        UpdateRotation();
        IncrementSpeed();
        TrackAndCompareU();
    }

    private void TrackAndCompareU()
    {
        if (Mathf.FloorToInt(_lastFrameU) < Mathf.FloorToInt(CurrentLevelU))
            OnLevelUIncremented?.Invoke();

        _lastFrameU = CurrentLevelU;
    }

    private void IncrementSpeed()
    {
        _speed += (Time.timeAsDouble-_lastFrameTime)/1000.0;

        _lastFrameTime = Time.timeAsDouble;
    }

    public void TogglePause()
    {
        _paused = !_paused;
    }

    private void UpdatePosition() => transform.position = _level.GetPointVector3(CurrentLevelU);
    private void UpdateRotation() => transform.rotation = _level.GetRotation(CurrentLevelU);



}
