using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsStrafing : Strafing {
    public float Power;
    public Rigidbody rigidbody;

    public void UpdateMoveAcceleration(ForceMode forceMode)
    {
        rigidbody.AddForce(Direction * Power, forceMode);
    }
}
