using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour {

    public string LeveltoLoad;

	public void PlayButtonPress()
    {
        SceneManager.LoadScene(LeveltoLoad);
    }
}
