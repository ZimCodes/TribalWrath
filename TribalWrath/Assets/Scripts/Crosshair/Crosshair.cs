using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour {

	[SerializeField]Texture2D image;
	[SerializeField]int size;
	[SerializeField]float maxAngle;
	[SerializeField]float minAngle;

	float lookHeight;

	public void Lookheight(float value){
		lookHeight += value;

		if(lookHeight > maxAngle || lookHeight < minAngle)
			lookHeight -= value;
	}

//	void OnGUI() {
//		Vector3 screenPosition = Camera.mainWorldToScreenPoint (transform.position);
//		screenPostion.y = Screenheight - screenPosition.y;
//		GUI.DrawTexture (new Rect (screenPosition.x, screenPostion.y - lookHeight, size, size), image);
//	}
}
	
