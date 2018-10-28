using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Single Item ObjectPooler
/// </summary>
public class ObjectPooler : MonoBehaviour {
    public GameObject recycleObject;
    private List<GameObject> objcontainer;

    public ObjectPooler()
    {

    }
    /// <summary>
    /// (Must be placed in Start()) Initializes the pool with object(s)
    /// </summary>
    /// <param name="_poolstartamount">Amount of objects to add to the pool in the beginning.</param>
    public void InitializePool () {
        objcontainer = new List<GameObject>();
        GameObject obj = recycleObject;
        obj.SetActive(false);
        objcontainer.Add(obj);
	}
    /// <summary>
    /// Retrieves a Deactivated Object from the pool
    /// </summary>
    /// <returns>Returns a deactivated object from the pool</returns>
    public GameObject getDeactivatedObject()
    {
        for (int i = 0; i < objcontainer.Count; i++)
        {
            if (!objcontainer[i].activeInHierarchy)
            {
                return objcontainer[i];
            }
        }
        return addNewObject();
    }
    /// <summary>
    /// Adds new object to pool
    /// </summary>
    /// <returns>Returns a new deactivated gameobject</returns>
    private GameObject addNewObject()
    {
        GameObject obj = Instantiate(recycleObject);
        obj.SetActive(false);
        objcontainer.Add(obj);
        return objcontainer[objcontainer.Count - 1];
    }
}
