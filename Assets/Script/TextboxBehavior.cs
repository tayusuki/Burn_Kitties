using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextboxBehavior : MonoBehaviour {

    Text textbox;
    string text;


	void Start () {
        textbox = GetComponent<Text>();
	}
	
	void Update () {
		
	}

    void SaySomething()
    {
        //enable textbox
        //animate text (stop all coroutines, in case another event triggers a box)
        //set timer to disable the box after all text is visible
    }
}
