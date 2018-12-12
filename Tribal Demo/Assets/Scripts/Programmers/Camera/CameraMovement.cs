using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : ICameraMovement {
    public GameObject targetObject { get; set; }
    protected static Vector3 cameraDistance { get; set; }
    int layerToIgnore;
    float moveCameraPercent;//Percentage to move camera forward during collision w/ another object
    /// <summary>
    /// Base constructor for all Camera Movement scripts
    /// </summary>
    /// <param name="_target">The target gameobject</param>
    /// <param name="_movecamerapercent">Percentage to move camera forward during collision w/ another object (optional)</param>
    /// <param name="_nameoflayertoignore">Name of layer to ignore (default:"Player")</param>
    public CameraMovement(GameObject _target, float _movecamerapercent = .347f,string _nameoflayertoignore = "Player")
    {
        layerToIgnore = 1 << LayerMask.NameToLayer(_nameoflayertoignore);
        targetObject = _target;
        moveCameraPercent = _movecamerapercent;
    }
    public virtual void Start(Transform cameraTransform)
    {
        layerToIgnore = ~layerToIgnore;
        cameraDistance = cameraTransform.position - targetObject.transform.position;
    }
    public virtual void LateUpdate(Transform cameraTransform)
    {
        cameraTransform.position = targetObject.transform.position + cameraDistance;
        CameraCollision(cameraTransform);
        //Debug.DrawLine(cameraTransform.position, cameraTransform.position - cameraDistance,Color.red);
    }
    /// <summary>
    /// Prevents Camera from clipping through walls
    /// </summary>
    /// <param name="cameraTransform">The camera transform</param>
    private void CameraCollision(Transform cameraTransform)
    {
        RaycastHit hit;
        
        if (Physics.Linecast(cameraTransform.position,targetObject.transform.position,out hit,layerToIgnore))
        {
            cameraTransform.position = Vector3.Lerp(cameraTransform.position, targetObject.transform.position, (hit.distance * moveCameraPercent));
        }
    }
}
