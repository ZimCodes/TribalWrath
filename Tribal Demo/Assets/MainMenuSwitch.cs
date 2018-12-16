using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
public enum MainMenuState { FirstScreen,SecondScreen};
public class MainMenuSwitch : MonoBehaviour {
    public static MainMenuState state = MainMenuState.FirstScreen;
    public Animator startAnim, creditAnim, quitAnim,chestAnim,cameraAnim;
    public Button MainMenuButton; 
	// Use this for initialization
	void Start () {
        startAnim = startAnim.GetComponent<Animator>();
        creditAnim = creditAnim.GetComponent<Animator>();
        quitAnim = quitAnim.GetComponent<Animator>();
        chestAnim = chestAnim.GetComponent<Animator>();
        cameraAnim = cameraAnim.GetComponent<Animator>();
        MainMenuButton = MainMenuButton.GetComponent<Button>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Escape) && state == MainMenuState.SecondScreen)
        {
            startAnim.Play("StartHidden");
            creditAnim.Play("CreditsHidden");
            quitAnim.Play("QuitHidden");
            chestAnim.Play("ChestClose");
            cameraAnim.Play("CameraBack");
            MainMenuButton.gameObject.SetActive(true);
            state = MainMenuState.FirstScreen;
            Debug.Log(state);
        }
	}
}
