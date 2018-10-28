using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOrb : MonoBehaviour {

    public GameObject lightPickup;
    public GameObject lightMarker;

    private Renderer orbRenderer;

    // Use this for initialization
    void Start()
    {
        orbRenderer = lightMarker.GetComponent<Renderer>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            orbRenderer.material.shader = Shader.Find("_Color");
            orbRenderer.material.SetColor("_Color", Color.yellow);

            orbRenderer.material.shader = Shader.Find("Specular");
            orbRenderer.material.SetColor("_SpecColor", Color.yellow);


            this.gameObject.SetActive(false);
        }

    }
}
