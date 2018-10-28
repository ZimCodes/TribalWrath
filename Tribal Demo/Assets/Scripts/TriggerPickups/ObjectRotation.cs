using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotation : MonoBehaviour {

    //Rotation Speed
    public float degreesPerSecond = 40f;

    //Up and Down distance
    public float amplitude = 0.1f;

    //Up and Down Frequency
    public float frequency = 1f;

    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    void Start()
    {
        posOffset = transform.position;
    }

    void Update()
    {
       
        transform.Rotate(new Vector3(0f, Time.deltaTime * degreesPerSecond, 0f), Space.World);

        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

        transform.position = tempPos;
    }
}
