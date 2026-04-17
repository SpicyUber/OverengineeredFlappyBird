using System;
 
using UnityEngine;

public class Rail : Singleton<Rail>
{
    [SerializeField] double _speed = 0.25f;
    [SerializeField] LevelSpline _level;

    private Quaternion _endRotation = Quaternion.identity;

    private double _lastFrameTime=0;

    private bool _paused = false;
    public float CurrentLevelU => Time.time * (float)_speed;
    private void Update()
    {
        if (_paused) return;
        UpdatePosition();
        UpdateRotation();
        IncrementSpeed();
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
