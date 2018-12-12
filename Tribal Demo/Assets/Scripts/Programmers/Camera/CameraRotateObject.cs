using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotateObject : CameraRotate {
    public float targetRotationSpeed;
    public CameraRotateObject(GameObject _target, float _movecamerapercent = .347f, string _nameoflayertoignore = "Player") : base(_target,_movecamerapercent,_nameoflayertoignore)
    {

    }
    public override void LateUpdate(Transform cameraTransform)
    {
        RotationFormula();

        base.LateUpdate(cameraTransform);
        RotateObjectFormula(cameraTransform);
    }
    protected override void RotationFormula()
    {
        base.RotationFormula();
        MaintainCameraDistanceWhileRotating();
    }
    private void RotateObjectFormula(Transform cameraTransform)
    {
        Quaternion targetTurnAngle = Quaternion.AngleAxis(RotateDirection * targetRotationSpeed, AxisToRotateAbout);
        targetObject.transform.Rotate(targetTurnAngle.eulerAngles);
        
    }

}
