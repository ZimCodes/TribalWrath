using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidSpitPooler : MonoBehaviour {
    ObjectPooler pooler;
    Timer timer;
    public GameObject itemToPoolRigid;
    private bool StartBulletFired = false;
    public AcidSpitPooler()
    {
        timer = new Timer();
    }
    // Use this for initialization
    void Start()
    {
        pooler = new ObjectPooler();
        pooler.recycleObject = Instantiate(itemToPoolRigid.gameObject,this.transform.position,transform.rotation);
        pooler.InitializePool();
    }

    // Update is called once per frame
    void FixedUpdate () {
        ShootInput();
        //cooldown
        timer.PlayTimerOnce(3);
    }
    private void ShootInput()
    {
        if (Input.GetMouseButtonDown(0) && !StartBulletFired)
        {
            StartBulletFired = true;
            ActivateObject();
        }
        else if (Input.GetMouseButtonDown(0) && timer.IsTimeUp)
        {
            ActivateObject();
            timer.ResetTimer();
        }
    }
    private void ActivateObject()
    {
        GameObject obj = pooler.getDeactivatedObject();
        //lift
        obj.transform.position = this.transform.position + this.transform.forward + new Vector3(0,0.5f,0);
        obj.SetActive(true);
        Movement(obj);

    }
    private void Movement(GameObject _obj)
    {
        Rigidbody rb = _obj.GetComponent<Rigidbody>();
        //Speed
        rb.AddForce(this.transform.forward * 300);
    }
}
