using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidSpit : MonoBehaviour {

	GameObject prefab;

	private float cooldown = 0;
	private const float ShootInterval = 3f;

	void Start () {
		prefab = Resources.Load ("Spit") as GameObject;
	}

	void Shoot()
	{
		if(cooldown > 1)
			return;

		// shoot bullet
		cooldown = ShootInterval;
	}

	void Update () {
		
		cooldown -= Time.deltaTime;

		if (Input.GetMouseButtonDown(0))
		{
			GameObject spit = Instantiate (prefab) as GameObject;
			spit.transform.position = transform.position + Camera.main.transform.forward * 1;
			Rigidbody rb = spit.GetComponent<Rigidbody> ();
			rb.velocity = Camera.main.transform.forward * 10;

		}
	}
}
