using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBarrier : MonoBehaviour {

	public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Rock")
        {
            Destroy(gameObject);
        }
    }
}
