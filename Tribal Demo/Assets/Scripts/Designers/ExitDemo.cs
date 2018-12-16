using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDemo : MonoBehaviour {

    public string LeveltoLoad;
    public static bool endlevel = false;
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            endlevel = true;
            SceneManager.LoadScene(LeveltoLoad);
        }
    }
}
