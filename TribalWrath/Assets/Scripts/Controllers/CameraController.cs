using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    CameraRotateObject cameraRotate;
    CameraFollow cameraFollow;

    public GameObject target;
    public float CameraRotationSpeed = 5.0f;
    public bool lookAtObject = true, ActivateRotation = true, follow = true;
    // Use this for initialization
    void Start () {
        cameraRotate = new CameraRotateObject(target);
        cameraFollow = new CameraFollow(target);

        cameraFollow.Start(this.transform);
        cameraRotate.Start(this.transform);
    }
	
	// Update is called once per frame
	void LateUpdate () {
        if (follow)
        {
            cameraFollow.LateUpdate(this.transform);
        }
        if (ActivateRotation)
        {
            //For Designers
            cameraRotate.CameraRotationSpeed = CameraRotationSpeed;
            cameraRotate.targetRotationSpeed = CameraRotationSpeed;
            cameraRotate.RotateDirection = Input.GetAxis("Mouse X");
            cameraRotate.LateUpdate(this.transform);
        }
        if (lookAtObject)
        {
            cameraRotate.LookAtObject(this.transform);
        }
    }
}
