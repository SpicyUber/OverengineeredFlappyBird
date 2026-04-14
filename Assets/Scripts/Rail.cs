using System;
using UnityEngine;

public class Rail : MonoBehaviour
{
    [SerializeField] float _speed = 0.25f;
    [SerializeField] LevelSpline _level;

   
    private void Update()
    {
        
        transform.position = _level.GetPointVector3(Time.time); 

    }

   
}
