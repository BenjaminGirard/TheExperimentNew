using UnityEngine;
using System.Collections;

public class controlScript : MonoBehaviour {
	
	Animator anim;
	void Awake () {anim=GetComponent<Animator>();}
	
	void Start () {
		anim.Play("walkSide");
	}
	//---------------------------
	void OnGUI() {
		
		 GUIStyle customButton = new GUIStyle("button");
		customButton.fontSize =24;
		
        //if (GUI.Button(new Rect(10, 10, 150, 50), "Enter",customButton))anim.Play("enter");
		
		if (GUI.Button(new Rect(10, 80, 150, 50), "Idle1",customButton))anim.Play("idle1");
		
		//if (GUI.Button(new Rect(10, 150, 150, 50), "Idle2",customButton))anim.Play("idle2");
		
		if (GUI.Button(new Rect(10, 220, 150, 50), "WalkSide",customButton))anim.Play("walkSide");
		
		if (GUI.Button(new Rect(10, 290, 150, 50), "WalkUp",customButton))anim.Play("walkUp");
		
		if (GUI.Button(new Rect(Screen.width-160, 10, 150, 50), "WalkDown",customButton))anim.Play("walkDown");
		
		//if (GUI.Button(new Rect(Screen.width-160, 80, 150, 50), "Strike",customButton))anim.Play("strike");
		
		//if (GUI.Button(new Rect(Screen.width-160, 150, 150, 50), "Bite",customButton))anim.Play("bite");
		
		if (GUI.Button(new Rect(Screen.width-160, 220, 150, 50), "Die",customButton))anim.Play("die");
		
		if (GUI.Button(new Rect(Screen.width-160, 290, 150, 50), "Headshot",customButton))anim.Play("headshot");
		
		
    }// end of ongui
}
