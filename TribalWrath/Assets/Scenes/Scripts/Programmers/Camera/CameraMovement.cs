using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : ICameraMovement {
    public GameObject targetObject { get; set; }
    protected Vector3 cameraDistance { get; set; }

    public CameraMovement(GameObject _target)
    {
        targetObject = _target;
    }
    public virtual void Start(Transform cameraTransform)
    {
        cameraDistance = cameraTransform.position - targetObject.transform.position;
    }
    public virtual void LateUpdate(Transform cameraTransform)
    {
        cameraTransform.position = targetObject.transform.position + cameraDistance;
    }
}
