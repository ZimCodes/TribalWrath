using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : Abilities, IMovement
{
    //public Vector3 Direction { get; set; }
    //public Rigidbody rigidbody { get; set; }
    public float jumpPower,jumpHeight,highJumpHeight, savedJumpHeight,savedHighJumpHeight;
    public bool isJumping;
    public Jumping()
    {
        Ability = AbilityState.HighJump;
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
    public void MaximumjumpHeightCheck(GameObject gameObject,AbilityState ability)
    {
        if (ability == AbilityState.HighJump)
        {
            if (gameObject.transform.position.y >= highJumpHeight)
            {
                this.Direction = Vector3.zero;
            }
        }
        else
        {
            if (gameObject.transform.position.y >= jumpHeight)
            {
                this.Direction = Vector3.zero;
            }
        }
        
    }
    public void newJumpHeight(GameObject gameObject,AbilityState ability)
    {
        if (ability == AbilityState.HighJump)
        {
            highJumpHeight = gameObject.transform.position.y + savedHighJumpHeight;
        }
        else
        {
            jumpHeight = gameObject.transform.position.y + savedJumpHeight;
        }
        

    }
}
