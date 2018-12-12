using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : CameraMovement { 

    public CameraFollow(GameObject _target, float _movecamerapercent = .347f, string _nameoflayertoignore = "Player") : base(_target,_movecamerapercent,_nameoflayertoignore)
    {

    }
    public override void LateUpdate(Transform cameraTransform)
    {
        base.LateUpdate(cameraTransform);
    }
}
