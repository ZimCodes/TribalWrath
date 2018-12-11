using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleBlock : MonoBehaviour {

    public Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = false;
    }

    public void OnTriggerEnter(Collider vision)
    {
        if (vision.gameObject.tag == "Orb")
        {
            rend.enabled = true;
            Debug.Log("seen");
        }
    }

    public void OnTriggerExit(Collider vision)
    {
        if (vision.gameObject.tag == "Orb")
        {
            rend.enabled = false;
            Debug.Log("seen");
        }
    }
}
