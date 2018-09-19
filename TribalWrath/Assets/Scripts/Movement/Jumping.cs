using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : IMovement {
    public Vector3 Direction { get; set; }
    public Rigidbody rigidbody;
    public float jumpPower,jumpHeight;
    public bool isJumping;
    public void UpdateJumpMovement(ForceMode forceMode)
    {
        rigidbody.AddForce(Direction * jumpPower);
    }
    
}
