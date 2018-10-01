using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AbilityState { Normal, HighJump, AcidSpit, OwlSight};

public class Abilities : IAbilities
{
    public AbilityState Ability;
    public Vector3 Direction { get; set; }
    public Rigidbody rigidbody { get; set;}
}
