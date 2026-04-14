using UnityEngine;

public class LevelGizmoDrawer: MonoBehaviour
{
    [SerializeField] LevelSpline _levelSpline;

    [Header("For Testing")]
    [SerializeField] bool _displayGizmos;
    [SerializeField]
    [Range(0.01f, 1f)] float _gizmosSplineInterval, _gizmosSplineSphereRadius;
  

    private void OnDrawGizmos()
    {
        if (!_displayGizmos || _gizmosSplineInterval < 0.01f)
            return;

        DrawSpline();
        DrawTangentPoints();
        DrawEdgePoints();
    }

    private void DrawTangentPoints()
    {
        Gizmos.color = Color.orange;

        for (int i = 0; i < _levelSpline.GetMaxU(); i++)
        {
            BezierCurve curve = _levelSpline.GetBezierCurveAtIndex(i);

            Gizmos.DrawSphere(new Vector3(curve.P1.x, 0, curve.P1.y), _gizmosSplineSphereRadius);
            Gizmos.DrawSphere(new Vector3(curve.P2.x, 0, curve.P2.y), _gizmosSplineSphereRadius);
        }
    }

    private void DrawSpline()
    {
        for (float i = 0; i < _levelSpline.GetMaxU(); i += _gizmosSplineInterval)
            Gizmos.DrawSphere(_levelSpline.GetPointVector3(i), _gizmosSplineSphereRadius);
    }

    private void DrawEdgePoints()
    {
        Gizmos.color = Color.green;

        for (int i = 0; i < _levelSpline.GetMaxU(); i++)
        {
            BezierCurve curve = _levelSpline.GetBezierCurveAtIndex(i);

            Gizmos.DrawSphere(new Vector3(curve.P0.x, 0, curve.P0.y), _gizmosSplineSphereRadius);
            Gizmos.DrawSphere(new Vector3(curve.P3.x, 0, curve.P3.y), _gizmosSplineSphereRadius);
        }
    }
}
