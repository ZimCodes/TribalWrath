using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwlSightController : MonoBehaviour {
    LightSwitch owlsight;
    [Header("Owl Light Ability Settings"), Space(2)]
    [Tooltip("The Type of Light you would like to use for the Owl ability.")]
    public Light lightObject;
    // Use this for initialization
    void Start () {
        owlsight = new LightSwitch(lightObject);
        owlsight.Start();
	}
	
	// Update is called once per frame
	void Update () {
        if (Abilities.Ability != AbilityState.OwlSight)
        {
            owlsight.state = LightState.LightOff;
        }
        else
        {
            owlsight.state = LightState.LightOn;
        }
	}
    private void LateUpdate()
    {
        owlsight.LateUpdate();
    }
}
