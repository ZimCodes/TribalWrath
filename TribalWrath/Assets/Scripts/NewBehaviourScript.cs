using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    //public void UpdateInput()
    //{
    //    Vector3 currentRotation = this.gameObject.transform.eulerAngles;

    //    strafing.Direction = Vector3.zero;
    //    if (KeyboardInputUtil.IsHoldingKey(KeyCode.W))
    //    {
    //        //strafing.Direction += new Vector3(0, 0, 1);
    //        strafing.Direction += new Vector3(1, 0, 0);
    //    }
    //    if (KeyboardInputUtil.IsHoldingKey(KeyCode.D))
    //    {
    //        //strafing.Direction += new Vector3(1, 0, 0);
    //        strafing.Direction += new Vector3(0, 0, -1);
    //    }
    //    if (KeyboardInputUtil.IsHoldingKey(KeyCode.S))
    //    {
    //        //strafing.Direction += new Vector3(0, 0, -1);
    //        strafing.Direction += new Vector3(-1, 0, 0);
    //    }
    //    if (KeyboardInputUtil.IsHoldingKey(KeyCode.A))
    //    {
    //        //strafing.Direction += new Vector3(-1, 0, 0);
    //        strafing.Direction += new Vector3(0, 0, 1);
    //    }
    //    //strafing.Direction.Normalize();
    //    Vector3 DirectionWRotation = Vector3.Cross(strafing.Direction, currentRotation);
    //    float DirWRotX = Mathf.Cos(DirectionWRotation.x);
    //    float DirWRotZ = Mathf.Sin(DirectionWRotation.z);

    //    Debug.Log("Direction: " + DirectionWRotation);
    //    Debug.Log("newDir: " + new Vector3(DirWRotZ, 0, DirWRotX));
    //    //strafing.Direction = Vector3.Normalize(Vector3.Cross(strafing.Direction, currentRotation));
    //    strafing.Direction = new Vector3(DirWRotZ, 0, DirWRotX);
    //}
}
