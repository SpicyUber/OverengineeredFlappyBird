using UnityEngine;

public class CameraLogic : MonoBehaviour
{
    [SerializeField] Transform _positionTransform;
    [SerializeField] Transform _lookAtTransform;
    [SerializeField] float _rotationSpeed=10f;

    private void LateUpdate()
    {  transform.position = _positionTransform.position;
        var forward = _lookAtTransform.position - _positionTransform.position;
        forward.Normalize();
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(forward,Vector3.up),Time.deltaTime*_rotationSpeed);
    }
}
