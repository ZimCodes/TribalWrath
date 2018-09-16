using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour {
    [Tooltip("Go to the Unity Documentation for more details")]
    public ForceMode forceMode = ForceMode.Force;
    Jumping jump;

    [Tooltip("Amount of Force Required to Jump")]
    public float jumpForce = 12;

    [Tooltip("Maximum Height to jump before descending")]
    public float jumpHeight = 5;

    // Use this for initialization
    void Start () {
        jump = new Jumping();
        jump.rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        UpdateJumpInput();

        //For Designers
        jump.jumpPower = jumpForce;
        jump.jumpHeight = jumpHeight;

        jump.UpdateJumpMovement(forceMode);
        MaximumjumpHeightCheck();
	}
    private void UpdateJumpInput()
    {
        if (KeyboardInputUtil.KeyWasPressed(KeyCode.Space) && !jump.isJumping)
        {
            jump.Direction = Vector3.up;
            Debug.Log("Jumping!");
            jump.isJumping = true;
        }
        jump.Direction.Normalize();
    }
    private void MaximumjumpHeightCheck()
    {
        if (this.transform.position.y >= jumpHeight)
        {
            jump.Direction = Vector3.zero;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.contacts.Length > 0)
        {
            jump.isJumping = false;
            Debug.Log("Not Jumping");
        }
    }
}
