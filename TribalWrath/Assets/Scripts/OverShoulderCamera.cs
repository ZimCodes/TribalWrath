using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverShoulderCamera : MonoBehaviour {

    private Vector3 CameraDistance;
    public GameObject gameObject;

    private void Start()
    {
        CameraDistanceFromObject(gameObject);
    }
    private void LateUpdate()
    {
        UpdateCameraDistance(gameObject);
    }

    private void CameraDistanceFromObject(GameObject gameObject)
    {
        CameraDistance = this.transform.position - gameObject.transform.position;
    }
    private void UpdateCameraDistance(GameObject gameObject)
    {
        this.transform.position = CameraDistance + gameObject.transform.position;
    }

}
