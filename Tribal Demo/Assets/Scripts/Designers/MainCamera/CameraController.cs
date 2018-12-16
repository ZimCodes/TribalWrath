using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    CameraRotateObject cameraRotate;
    CameraFollow cameraFollow;
    CameraRotateVertical cameraRotVertical;

    public GameObject target;
    [Tooltip("Camera Rotation Speed on X-Axis")]
    public float CameraRotationXSpeed = 5.0f;
    [Tooltip("Camera Rotation Speed on Y-Axis")]
    public float CameraRotationYSpeed = 1.0f;
    [SerializeField,Range(0,1),Tooltip("Percent to move camera during collision w/ another object(No Runtime Changes!)")]
    private float cameraCollisionMovePercent = .347f;
    [SerializeField, Tooltip("Name of layer target is on; [Target must NOT be on layers 0-8]")]
    private string targetLayerName = "Player";
    public bool lookAtObject = true, ActivateRotation = true, follow = true, verticalcontrol = true, InvertY = false;
    // Use this for initialization
    void Start () {
        cameraRotate = new CameraRotateObject(target,cameraCollisionMovePercent,targetLayerName);
        cameraFollow = new CameraFollow(target, cameraCollisionMovePercent, targetLayerName);
        cameraRotVertical = new CameraRotateVertical(target, cameraCollisionMovePercent, targetLayerName);

        cameraFollow.Start(this.transform);
        cameraRotate.Start(this.transform);
        cameraRotVertical.Start(this.transform);
    }
	
	// Update is called once per frame
	void LateUpdate () {
        #region If No ModelSwitch Script is attached to scene
        if (ModelSwitch.currentModel == null)
        {
            cameraRotate.targetObject =  target;
        }
        else
        {
            cameraFollow.targetObject = ModelSwitch.currentModel;
            cameraRotate.targetObject = ModelSwitch.currentModel;
            cameraRotVertical.targetObject = ModelSwitch.currentModel;
        }
        #endregion
        if (follow)
        {
            cameraFollow.LateUpdate(this.transform);
        }
        if (AbilityBtnWheel.AbilityWheelState == AbilityWheelUIState.Hidden)
        {
            
            if (ActivateRotation)
            {
                //For Designers
                cameraRotate.CameraRotationSpeed = CameraRotationXSpeed;
                cameraRotate.targetRotationSpeed = CameraRotationXSpeed;
                cameraRotate.RotateDirection = Input.GetAxis("Mouse X");
                cameraRotate.LateUpdate(this.transform);
            }
            if (verticalcontrol)
            {
                cameraRotVertical.CameraRotationSpeed = CameraRotationYSpeed;
                cameraRotVertical.VerticalRotation = Input.GetAxis("Mouse Y");
                cameraRotVertical.VerticalRotation = (InvertY) ? Input.GetAxis("Mouse Y") : Input.GetAxis("Mouse Y") * -1;


                cameraRotVertical.LateUpdate(this.transform);
            }
            if (lookAtObject)
            {
                cameraRotate.LookAtObject(this.transform);
            }
        }
        
        

    }
}
