using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidSpit : Abilities {

    ObjectPooler pooler;
    Timer timer;
    private bool StartBulletFired = false;
    public float cooldown, projectileSpeed, verticalStartForProjectile;
    public AcidSpit( float _projectilespeed, float _cooldown, float _verticalstart)
    {
        timer = new Timer();

        projectileSpeed = _projectilespeed;
        cooldown = _cooldown;
        verticalStartForProjectile = _verticalstart;
        Ability = AbilityState.AcidSpit;
    }
    // Use this for initialization
    public void Start(GameObject _itemToPool)
    {
        pooler = new ObjectPooler();
        pooler.recycleObject = _itemToPool;
        pooler.InitializePool();
    }

    // Update is called once per frame
    public void FixedUpdate(GameObject player)
    {
        ShootInput(player);
        //cooldown - 3
        timer.PlayTimerOnce(cooldown);
    }
    private void ShootInput(GameObject player)
    {
        if (Input.GetMouseButtonDown(0) && !StartBulletFired)
        {
            StartBulletFired = true;
            ActivateObject(player);
        }
        else if (Input.GetMouseButtonDown(0) && timer.IsTimeUp)
        {
            ActivateObject(player);
            timer.ResetTimer();
        }
    }
    private void ActivateObject(GameObject player)
    {
        GameObject obj = pooler.getDeactivatedObject();
        //lift - 0.5f
        obj.transform.position = player.transform.position + player.transform.forward + new Vector3(0, verticalStartForProjectile, 0);
        obj.SetActive(true);
        Movement(obj,player);

    }
    private void Movement(GameObject _obj,GameObject player)
    {
        Rigidbody rb = _obj.GetComponent<Rigidbody>();
        //Speed - 300
        rb.AddForce(player.transform.forward * projectileSpeed);
    }
}
