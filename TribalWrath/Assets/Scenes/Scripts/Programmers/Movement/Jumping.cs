using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : Abilities, IMovement
{
    //public Vector3 Direction { get; set; }
    //public Rigidbody rigidbody { get; set; }
    public float jumpPower,jumpHeight,savedJumpHeight;
    public bool isJumping;
    public Jumping()
    {

    }

    public void UpdateJumpMovement(ForceMode forceMode)
    {
        rigidbody.AddForce(Direction * jumpPower);
    }
    public void MaximumjumpHeightCheck(GameObject gameObject)
    {
        if (gameObject.transform.position.y >= jumpHeight)
        {
            this.Direction = Vector3.zero;
        }
    }
    public void newJumpHeight(GameObject gameObject)
    {
        jumpHeight = gameObject.transform.position.y + savedJumpHeight;
    }
}
