using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorUtility : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {
        if (AbilityBtnWheel.AbilityWheelState == AbilityWheelUIState.Visible)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
	}
}
