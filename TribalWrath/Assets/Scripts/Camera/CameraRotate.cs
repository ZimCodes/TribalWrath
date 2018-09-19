using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : CameraMovement {

    public float CameraRotationSpeed, RotateDirection;
    protected Vector3 AxisToRotateAbout;

    protected Quaternion camTurnAngle;
    public CameraRotate(GameObject _target): base(_target)
    {
        AxisToRotateAbout = Vector3.up;
    }
    public override void Start(Transform cameraTransform)
    {
        base.Start(cameraTransform);
    }
    public override void LateUpdate(Transform cameraTransform)
    {
        base.LateUpdate(cameraTransform);
    }
    protected virtual void RotationFormula()
    {
        camTurnAngle = Quaternion.AngleAxis(RotateDirection * CameraRotationSpeed, AxisToRotateAbout);
    }
    public void LookAtObject(Transform cameraTransform)
    {
        cameraTransform.LookAt(targetObject.transform.position);
    }
    protected void MaintainCameraDistanceWhileRotating()
    {
        cameraDistance = camTurnAngle * cameraDistance;
    }
}
