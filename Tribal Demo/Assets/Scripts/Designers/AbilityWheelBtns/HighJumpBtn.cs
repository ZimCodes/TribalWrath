using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HighJumpBtn : MonoBehaviour, IPointerEnterHandler {

public void OnPointerEnter(PointerEventData eventData)
    {
        Abilities.Ability = AbilityState.HighJump;
    }
}
