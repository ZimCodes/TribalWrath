using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KineticStrafing : Strafing {

    public float Speed;

    public void UpdateMovement(GameObject gameObject)
    {
        //Vector3 moveTransform = new Vector3(this.Direction.x, 0, this.Direction.z) * Time.deltaTime * this.Speed;
        //return new Vector3(moveTransform.x, 0, moveTransform.z);
        gameObject.transform.Translate(this.Direction * this.Speed * Time.deltaTime);
    }
}
