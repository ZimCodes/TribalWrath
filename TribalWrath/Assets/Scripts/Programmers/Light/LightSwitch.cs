using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum LightState {LightOn,LightOff};
public class LightSwitch : Abilities {
    public LightState state;
    private Light light;
    public LightSwitch(Light _light)
    {
        light = _light;
    }
    public void Start()
    {
        if (light.isActiveAndEnabled)
        {
            state = LightState.LightOn;
        }
        else
        {
            state = LightState.LightOff;
        }
    }
    public void LateUpdate()
    {
        SwitchLightState();
    }
    private void SwitchLightState()
    {
        switch (state)
        {
            case LightState.LightOn:
                light.gameObject.SetActive(true);
                break;
            case LightState.LightOff:
                light.gameObject.SetActive(false);
                break;
            default:
                break;
        }
    }
}
