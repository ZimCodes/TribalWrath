using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsStrafingController : MonoBehaviour {
    PhysicsStrafing strafing;

    [Tooltip("Go to Unity Documentation for more details")]
    public ForceMode forceMode = ForceMode.Force;

    [Tooltip("Amount of Force to move an Object")]
    public float Force = 12;

    // Use this for initialization
    void Start () {
        strafing = new PhysicsStrafing();
        strafing.rigidbody = GetComponent<Rigidbody>();
        strafing.Direction = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
        UpdateInput();
        //For Designers
        strafing.Power = Force;

        strafing.UpdateMoveAcceleration(forceMode);
	}
    public void UpdateInput()
    {
        strafing.Direction = Vector3.zero;
        if (KeyboardInputUtil.IsHoldingKey(KeyCode.W))
        {
            strafing.Direction += new Vector3(0, 0, 1);
        }
        if (KeyboardInputUtil.IsHoldingKey(KeyCode.D))
        {
            strafing.Direction += new Vector3(1, 0, 0);
        }
        if (KeyboardInputUtil.IsHoldingKey(KeyCode.S))
        {
            strafing.Direction += new Vector3(0, 0, -1);
        }
        if (KeyboardInputUtil.IsHoldingKey(KeyCode.A))
        {
            strafing.Direction += new Vector3(-1, 0, 0);
        }
        strafing.Direction.Normalize();
    }
}
