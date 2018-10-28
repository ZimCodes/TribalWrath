using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpitOrb : MonoBehaviour
{

    public GameObject spitPickup;
    public GameObject spitMarker;

    private Renderer orbRenderer;

    // Use this for initialization
    void Start()
    {
        orbRenderer = spitMarker.GetComponent<Renderer>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            orbRenderer.material.shader = Shader.Find("_Color");
            orbRenderer.material.SetColor("_Color", Color.green);

            orbRenderer.material.shader = Shader.Find("Specular");
            orbRenderer.material.SetColor("_SpecColor", Color.green);


            this.gameObject.SetActive(false);
        }

    }
}
