using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMenuState : MonoBehaviour {

	public void SetMainMenuState()
    {
        MainMenuSwitch.state = MainMenuState.SecondScreen;
    }
    
}
