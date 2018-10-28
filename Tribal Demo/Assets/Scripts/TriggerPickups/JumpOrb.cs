using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpOrb : MonoBehaviour {

    public GameObject jumpPickup;
    public GameObject jumpMarker;

    private Renderer orbRenderer;

    // Use this for initialization
    void Start () {
        orbRenderer = jumpMarker.GetComponent<Renderer>();
    }
	
	void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            orbRenderer.material.shader = Shader.Find("_Color");
            orbRenderer.material.SetColor("_Color", Color.blue);

            orbRenderer.material.shader = Shader.Find("Specular");
            orbRenderer.material.SetColor("_SpecColor", Color.blue);


            this.gameObject.SetActive(false);
        }

    }
}
