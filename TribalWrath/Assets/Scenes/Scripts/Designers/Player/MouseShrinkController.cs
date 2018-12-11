using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseShrinkController : MonoBehaviour {
    MouseShrink shrink;
    [Tooltip("The new scale for the gameobject.[No Runtime Changes]")]
    public Vector3 shrinkVector = new Vector3(0.25f,0.25f,0.25f);
	// Use this for initialization
	void Start () {
        shrink = new MouseShrink(this.gameObject,shrinkVector);
        shrink.Start();
	}
	
	// Update is called once per frame
	void Update () {
        shrink.Update();
	}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.contacts.Length > 0)
        {
            shrink.ChangeDefaultPosition(this.transform.position);
        }
    }
}
