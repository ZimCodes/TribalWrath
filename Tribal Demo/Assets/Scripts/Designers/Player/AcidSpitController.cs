using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidSpitController : MonoBehaviour {
    AcidSpit acidshooting;

    [Header("Acid Spit Ability Settings"), Space(2)]
    [Tooltip("(optional) Name of Projectile(can't change during Runtime)"), TextArea(1, 1)]
    public string projectileName = "Acid Spit";
    [Tooltip("The object to use as a projectile for Acid Spit")]
    public GameObject projectile;
    [Tooltip("How fast the acid projectile travels.")]
    public float AcidSpeed = 300;
    [Tooltip("The time it takes to shoot the next projectile.")]
    [Range(0, 10)]
    public float AcidCooldown = 3;
    [Tooltip("The initial vertical start position of the projectile.")]
    [Range(0, 2)]
    public float verticalStartForProjectile = 0.5f;

    // Use this for initialization
    void Start () {
        acidshooting = new AcidSpit(AcidSpeed, AcidCooldown, verticalStartForProjectile);
        acidshooting.Start(RenamingProjectile());
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        //For Designers
        acidshooting.projectileSpeed = AcidSpeed;
        acidshooting.cooldown = AcidCooldown;
        acidshooting.verticalStartForProjectile = verticalStartForProjectile;
        acidshooting.FixedUpdate(this.gameObject);
    }
    private GameObject RenamingProjectile()
    {
        GameObject tempobj = Instantiate(projectile, this.transform.position, this.transform.rotation);
        tempobj.name = projectileName;
        return tempobj;
    }
}
