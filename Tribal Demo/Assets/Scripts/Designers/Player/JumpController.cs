using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour {
    Jumping jump;

    [Header("Normal Jump Settings"), Space(2)]
    [Tooltip("Amount of Force Required to Jump")]
    public float jumpForce = 12;
    [Tooltip("Maximum Height to jump before descending")]
    public float jumpHeight = 5;
    [Tooltip("Go to the Unity Documentation for more details")]
    public ForceMode forceMode = ForceMode.Force;

    // Use this for initialization
    void Start () {
        jump = new Jumping();
        jump.rigidbody = GetComponent<Rigidbody>();
        jump.savedJumpHeight = jumpHeight;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        RegularJump(jumpForce, forceMode);
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
    private void RegularJump(float _jumpforce, ForceMode _forceMode)
    {
        UpdateJumpInput();

        jump.jumpPower = _jumpforce;
        jump.UpdateJumpMovement(_forceMode);
        jump.MaximumjumpHeightCheck(this.gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.contacts.Length > 0)
        {
            jump.isJumping = false;
            Debug.Log("Not Jumping");
            jump.newJumpHeight(this.gameObject);
        }
    }
}
