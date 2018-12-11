using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwlSight: MonoBehaviour
{
    LightSwitch owlsight;
    [Header("Owl Light Ability Settings"), Space(2)]
    [Tooltip("The Type of Light you would like to use for the Owl ability.")]

    //public GameObject InvisibleShit = InvisibleShit;

    public GameObject InvisibleShitPrefab;
    public GameObject[] InvisibleShit;





    public Light lightObject;
    // Use this for initialization
    void Start()
    {
        owlsight = new LightSwitch(lightObject);
        owlsight.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (Abilities.Ability != AbilityState.OwlSight)
        {
            owlsight.state = LightState.LightOff;
            InvisibleShitPrefab.SetActive(true);


        }
        else
        {
            owlsight.state = LightState.LightOn;
            //InvisibleShitPrefab=true;
            InvisibleShitPrefab.SetActive(true);
        }



    }
    private void LateUpdate()
    {
        owlsight.LateUpdate();
    }
}
