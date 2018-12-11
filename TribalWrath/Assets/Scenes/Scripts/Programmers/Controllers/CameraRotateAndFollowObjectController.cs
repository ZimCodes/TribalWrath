using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotateAndFollowObjectController : MonoBehaviour {
    CameraFollow cameraFollow;
    CameraRotate cameraRotateAround;

    public GameObject target;
    public float CameraRotationSpeed = 5.0f;
    public bool lookAtObject = true, ActivateRotation = true, follow = true;
	// Use this for initialization
	void Start () {
        cameraRotateAround = new CameraRotateAroundObject(target);
        cameraFollow = new CameraFollow(target);

        cameraFollow.Start(this.transform);
        cameraRotateAround.Start(this.transform);
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
            cameraRotateAround.CameraRotationSpeed = CameraRotationSpeed;
            cameraRotateAround.RotateDirection = Input.GetAxis("Mouse X");
            cameraRotateAround.LateUpdate(this.transform);
        }
        if (lookAtObject)
        {
            cameraRotateAround.LookAtObject(this.transform);
        }

	}
}
