using System;
using UnityEngine;

public class Rail : MonoBehaviour
{
    [SerializeField] float _speed = 0.25f;
    [SerializeField] LevelSpline _level;
    private Quaternion _endRotation = Quaternion.identity;
   
    private void Update()
    {

        UpdatePosition();

    }
    private void FixedUpdate()
    {
        FixedUpdateRotation();
    }

    private void UpdatePosition() => transform.position = _level.GetPointVector3(Time.time);
    private void FixedUpdateRotation() => transform.rotation = _level.GetRotation(Time.time);



}
