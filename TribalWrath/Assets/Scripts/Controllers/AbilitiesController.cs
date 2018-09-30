using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitiesController : MonoBehaviour {
    private AbilityState ability = AbilityState.Normal;
    [Tooltip("Go to the Unity Documentation for more details")]
    public ForceMode forceMode = ForceMode.Force;
    public ForceMode highJumpForceMode = ForceMode.Force;
    Jumping jump;

    [Tooltip("Amount of Force Required to Jump")]
    public float jumpForce = 12;
    [Tooltip("Maximum Height to jump before descending")]
    public float jumpHeight = 5;
    [Tooltip("Amount of Force Required to HIGH Jump")]
    public float highJumpForce = 12;
    [Tooltip("Maximum Height to HIGH Jump before descending")]
    public float highJumpHeight = 5;
    // Use this for initialization
    void Start()
    {
        jump = new Jumping();
        jump.rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        InputSwitchAbilities();

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
    private void InputSwitchAbilities()
    {
        if (KeyboardInputUtil.KeyWasPressed(KeyCode.Alpha1))
        {
            ability = AbilityState.HighJump;
        }
        AbilitySwitch();
    }
    private void AbilitySwitch()
    {
        switch (ability)
        {
            case AbilityState.Normal:
                RegularJump(jumpForce, jumpHeight, forceMode);
                break;
            case AbilityState.HighJump:
                RegularJump(highJumpForce, highJumpHeight, highJumpForceMode);
                break;
            case AbilityState.AcidSpit:
                //TODO: Enter code for projectile ability below

                RegularJump(jumpForce,jumpHeight,forceMode);
                break;
            default:
                ability = AbilityState.Normal;
                break;
        }
        jump.MaximumjumpHeightCheck(this.gameObject);
    }
    private void RegularJump(float _jumpforce,float _jumpheight, ForceMode _forceMode)
    {
        UpdateJumpInput();

        jump.jumpPower = _jumpforce;
        jump.jumpHeight = _jumpheight;
        jump.UpdateJumpMovement(_forceMode);
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
