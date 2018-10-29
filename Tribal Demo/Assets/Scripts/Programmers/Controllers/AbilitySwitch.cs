using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySwitch : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        InputSwitchAbilities();
    }

    private void InputSwitchAbilities()
    {
        if (KeyboardInputUtil.KeyWasPressed(KeyCode.Alpha1))
        {
            Abilities.Ability = AbilityState.HighJump;
        }
        else if (KeyboardInputUtil.KeyWasPressed(KeyCode.Alpha2))
        {
            Abilities.Ability = AbilityState.AcidSpit;
        }
        else if (KeyboardInputUtil.KeyWasPressed(KeyCode.Alpha3))
        {
            Abilities.Ability = AbilityState.OwlSight;
        }
        //else if(KeyboardInputUtil.KeyWasPressed(KeyCode.Alpha0))
        //{
        //    Abilities.Ability = AbilityState.Normal;
        //}
        Debug.Log("Ability: "+Abilities.Ability);
    }
}
