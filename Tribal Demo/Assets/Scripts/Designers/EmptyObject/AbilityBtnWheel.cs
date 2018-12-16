using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public enum AbilityWheelUIState { Hidden,Visible };
public class AbilityBtnWheel : MonoBehaviour {
    private static AbilityWheelUIState abilitywheelstate;
    public static AbilityWheelUIState AbilityWheelState
    {
        get
        {
            return abilitywheelstate; 
        }
        private set {  abilitywheelstate = AbilityWheelUIState.Hidden; } }

    public Button highJumpBtn, acidSpitBtn, owlSightBtn, mouseShrinkBtn, normalBtn;
    public Canvas UIForWheel;
    // Use this for initialization
    void Start ()
    {
        UIForWheel.GetComponent<Canvas>();
        DisableWheelUIOnStart();

        highJumpBtn.GetComponent<Button>();
        acidSpitBtn.GetComponent<Button>();
        owlSightBtn.GetComponent<Button>();
        normalBtn.GetComponent<Button>();
        mouseShrinkBtn.GetComponent<Button>();

    }
    private void OnGUI()
    {
        DisableCurrentButton();
    }
    /// <summary>
    /// Disables the Ability Wheel Canvas On Start
    /// </summary>
    private void DisableWheelUIOnStart()
    {
        if (UIForWheel.isActiveAndEnabled)
        {
            UIForWheel.enabled = false;
        }
    }

    private void Update()
    {
        WheelActivation();
    }
    private void WheelActivation()
    {
        if (InputUtil.IsHoldingKey(KeyCode.Tab))
        {
            UIForWheel.enabled = true;
            abilitywheelstate = AbilityWheelUIState.Visible;
            
        }
        else
        {
            UIForWheel.enabled = false;
            abilitywheelstate = AbilityWheelUIState.Hidden;
        }
    }
    /// <summary>
    /// Disables the button associated with the current selected ability
    /// </summary>
    private void DisableCurrentButton()
    {
        switch (Abilities.Ability)
        {
            case AbilityState.HighJump:
                highJumpBtn.interactable = false;
                acidSpitBtn.interactable = owlSightBtn.interactable = mouseShrinkBtn.interactable = normalBtn.interactable = true;
                break;
            case AbilityState.AcidSpit:
                acidSpitBtn.interactable = false;
                highJumpBtn.interactable = owlSightBtn.interactable = mouseShrinkBtn.interactable = normalBtn.interactable = true;
                break;
            case AbilityState.OwlSight:
                owlSightBtn.interactable = false;
                highJumpBtn.interactable = acidSpitBtn.interactable = mouseShrinkBtn.interactable = normalBtn.interactable = true;
                break;
            case AbilityState.MouseShrink:
                mouseShrinkBtn.interactable = false;
                highJumpBtn.interactable = acidSpitBtn.interactable = owlSightBtn.interactable = normalBtn.interactable = true;
                break;
            case AbilityState.Normal:
                normalBtn.interactable = false;
                highJumpBtn.interactable = acidSpitBtn.interactable = owlSightBtn.interactable = mouseShrinkBtn.interactable = true;
                break;
        }
    }
}
