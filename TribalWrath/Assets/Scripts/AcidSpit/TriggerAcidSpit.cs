using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAcidSpit : MonoBehaviour {
    Rigidbody AcidSpitrb;
    [Tooltip("The tag name for objects to collide with Acid Spit."), Multiline(1)]
    public string objectToCollideWithAcidSpit;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.ToLower() == objectToCollideWithAcidSpit.ToLower())
        {
            other.gameObject.SetActive(false);

            AcidSpitrb = this.GetComponent<Rigidbody>();
            AcidSpitrb.velocity = Vector3.zero;

            this.gameObject.SetActive(false);
        }
    }
}
