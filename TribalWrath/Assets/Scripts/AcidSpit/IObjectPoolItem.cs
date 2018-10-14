using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObjectPoolItem {
    //Rigidbody itemToPoolRigid { get; set; }
    float Speed { get; set; }
    void Movement();

}
