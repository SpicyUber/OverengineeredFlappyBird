
using System;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelSpline", menuName = "Scriptable Objects/LevelSpline")]
public class LevelSpline : ScriptableObject
{
    [SerializeField] BezierCurve[] _bezierCurves;

    private readonly float _getRotationInterval = 1f;
    public float GetMaxU() => _bezierCurves.Length;

    public BezierCurve GetBezierCurveAtIndex(int index) => _bezierCurves[index];
    public Vector3 GetPointVector3(float u)
    {
        Vector2 point = GetPointVector2(u);
        return new Vector3(point.x, 0, point.y);
    }
    private Vector2 GetPointVector2(float u)
    {
        u = u % (float)_bezierCurves.Length;
        int index = Mathf.FloorToInt(u);
        float t = u - index;
        return CalculateBezierCurvePoint(_bezierCurves[index], t);

    }

    private Vector2 CalculateBezierCurvePoint(BezierCurve bezierCurve, float t)
    {
        Vector2 P01 = Vector2.Lerp(bezierCurve.P0, bezierCurve.P1, t);
        Vector2 P12 = Vector2.Lerp(bezierCurve.P1, bezierCurve.P2, t);
        Vector2 P23 = Vector2.Lerp(bezierCurve.P2, bezierCurve.P3, t);
        Vector2 P0112 = Vector2.Lerp(P01, P12, t);
        Vector2 P1223 = Vector2.Lerp(P12, P23, t);

        return Vector2.Lerp(P0112, P1223, t);



    }

    public Quaternion GetRotation(float u)
    {
         
        Vector3 forward = GetForwardVector(u);
        return Quaternion.LookRotation(forward, Vector3.up);

    }

    public Vector3 GetForwardVector(float u)
    {
        Vector3 position1 = GetPointVector3(u);
        Vector3 position2 = GetPointVector3(u + _getRotationInterval);
        return (position2 - position1).normalized;
    }

    [ContextMenu("Enforce C1 Continuity")] 
    void EnforceC1Continuity() 
    {
        EnforceC0Continuity();
        for (int i = 1; i < _bezierCurves.Length; i++) { 
        
             
            _bezierCurves[i].P1 = 2*_bezierCurves[i-1].P3 -_bezierCurves[i-1].P2;
        
        }
    }

    [ContextMenu("Enforce C0 Continuity")]
    void EnforceC0Continuity()
    {
        for (int i = 1; i < _bezierCurves.Length; i++)
        {


            _bezierCurves[i].P0 =_bezierCurves[i - 1].P3 ;

        }
    }

    [ContextMenu("Enforce C0 Continuity For Loops")]
    void EnforceCircularC0Continuity()
    {
                EnforceC0Continuity();
              _bezierCurves[_bezierCurves.Length - 1].P3= _bezierCurves[0].P0;

         
    }

    [ContextMenu("Enforce C1 Continuity For Loops")]
    void EnforceCircularC1Continuity()
    {
        EnforceCircularC0Continuity();
        EnforceC1Continuity();
        _bezierCurves[0].P1 = 2 * _bezierCurves[_bezierCurves.Length - 1].P3 - _bezierCurves[_bezierCurves.Length - 1].P2;


    }


}
