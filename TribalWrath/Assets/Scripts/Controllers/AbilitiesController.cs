using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitiesController : MonoBehaviour {
    [Header("Owl Light Ability Settings"),Space(2)]
    [Tooltip("The Type of Light you would like to use for the Owl ability.")]
    public Light lightObject;

    private AbilityState ability = AbilityState.Normal;
    
    
    Jumping jump;
    AcidSpit acidshooting;
    LightSwitch light;

    [Header("Normal Jump Settings"), Space(2)]
    [Tooltip("Amount of Force Required to Jump")]
    public float jumpForce = 12;
    [Tooltip("Maximum Height to jump before descending")]
    public float jumpHeight = 5;
    [Tooltip("Go to the Unity Documentation for more details")]
    public ForceMode forceMode = ForceMode.Force;

    [Header("High Jump Ability Settings"), Space(2)]
    [Tooltip("Amount of Force Required to HIGH Jump")]
    public float highJumpForce = 12;
    [Tooltip("Maximum Height to HIGH Jump before descending")]
    public float highJumpHeight = 8;
    [Tooltip("Go to the Unity Documentation for more details")]
    public ForceMode highJumpForceMode = ForceMode.Force;

    [Header("Acid Spit Ability Settings"), Space(2)]
    [Tooltip("(optional) Name of Projectile(can't change during Runtime)"),TextArea(1,1)]
    public string projectileName = "Acid Spit";
    [Tooltip("The object to use as a projectile for Acid Spit")]
    public GameObject projectile;
    [Tooltip("How fast the acid projectile travels.")]
    public float AcidSpeed = 300;
    [Tooltip("The time it takes to shoot the next projectile.")]
    [Range(0,10)]
    public float AcidCooldown = 3;
    [Tooltip("The initial vertical start position of the projectile.")]
    [Range(0,2)]
    public float verticalStartForProjectile = 0.5f;
    // Use this for initialization
    void Start()
    {
        jump = new Jumping();
        jump.rigidbody = GetComponent<Rigidbody>();
        jump.savedJumpHeight = jumpHeight;
        jump.savedHighJumpHeight = jump.highJumpHeight = highJumpHeight;

        acidshooting = new AcidSpit(AcidSpeed,AcidCooldown,verticalStartForProjectile);
        acidshooting.Start(RenamingProjectile());

        light = new LightSwitch(lightObject);
        light.Start();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        InputSwitchAbilities();
        Debug.Log("Jump Height: " + jump.jumpHeight);
        Debug.Log("HighJump Height: " + jump.highJumpHeight);
        Debug.Log("Ability: " + ability);
    }
    private void LateUpdate()
    {
        light.LateUpdate();
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
            light.state = LightState.LightOff;
        }
        else if (KeyboardInputUtil.KeyWasPressed(KeyCode.Alpha2))
        {
            ability = AbilityState.AcidSpit;
            light.state = LightState.LightOff;
        }
        else if (KeyboardInputUtil.KeyWasPressed(KeyCode.Alpha3))
        {
            ability = AbilityState.OwlSight;
        }
        AbilitySwitch();
    }
    private void AbilitySwitch()
    {
        switch (ability)
        {
            case AbilityState.Normal:
                light.state = LightState.LightOff;
                RegularJump(jumpForce, forceMode);
                break;
            case AbilityState.HighJump:
                
                RegularJump(highJumpForce, highJumpForceMode);
                break;
            case AbilityState.AcidSpit:

                //TODO: Enter code for projectile ability below
                acidshooting.projectileSpeed = AcidSpeed;
                acidshooting.cooldown = AcidCooldown;
                acidshooting.verticalStartForProjectile = verticalStartForProjectile;
                acidshooting.FixedUpdate(this.gameObject);
                RegularJump(jumpForce, forceMode);
                break;
            case AbilityState.OwlSight:
                light.state = LightState.LightOn;
                RegularJump(jumpForce, forceMode);
                break;
            default:
                ability = AbilityState.Normal;
                break;
        }
        jump.MaximumjumpHeightCheck(this.gameObject,ability);
    }
    private void RegularJump(float _jumpforce, ForceMode _forceMode)
    {
        UpdateJumpInput();

        jump.jumpPower = _jumpforce;
        jump.UpdateJumpMovement(_forceMode);
        
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.contacts.Length > 0)
        {
            jump.isJumping = false;
            Debug.Log("Not Jumping");
            jump.newJumpHeight(this.gameObject,ability);
        }
    }
    private GameObject RenamingProjectile()
    {
        GameObject tempobj = Instantiate(projectile, this.transform.position, this.transform.rotation);
        tempobj.name = projectileName;
        return tempobj;
    }
}
