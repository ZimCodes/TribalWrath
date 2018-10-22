using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseShrink : Abilities {

    private Vector3 defaultScale, shrinkScale,defaultPosition,currentPosition;
    private GameObject gameObject;
    public MouseShrink(GameObject _gameobj,float _xscale,float _yscale,float _zscale)
    {
        this.gameObject = _gameobj;
        this.shrinkScale = new Vector3(_xscale,_yscale,_zscale);
    }
    public MouseShrink(GameObject _gameobj, Vector3 _shrinkvect)
    {
        this.gameObject = _gameobj;
        this.shrinkScale = _shrinkvect;
    }
	// Use this for initialization
	public void Start () {
        this.defaultScale = this.gameObject.transform.localScale;
        this.defaultPosition = this.gameObject.transform.position;
	}
	
	// Update is called once per frame
	public void Update () {
        //TODO: Adjust it for abilities and not its own independent inputs
        MouseShrinkInput();
    }
    private void MouseShrinkInput()
    {
        if (KeyboardInputUtil.KeyWasPressed(KeyCode.Keypad1))
        {
            this.gameObject.transform.localScale = this.shrinkScale;
        }
        else if (KeyboardInputUtil.KeyWasPressed(KeyCode.Keypad2))
        {
            currentPosition = this.gameObject.transform.position;
            if (currentPosition.y < defaultPosition.y)
            {
                this.gameObject.transform.position = this.defaultPosition;
            }
            this.gameObject.transform.localScale = this.defaultScale;
        }
    }
    public void ChangeDefaultPosition(Vector3 _objposition)
    {
        defaultPosition = _objposition;
        Debug.Log(defaultPosition);
    }
    
}
