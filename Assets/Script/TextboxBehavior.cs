using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextboxBehavior : MonoBehaviour {

    // Attach to Textbox (child of player) 

    Text textbox;
    internal string text;
    IEnumerator animator;

    float timer;
    bool canChange;

	void Start () {
        textbox = GetComponent<Text>();
	}
	
	void Update () {

        if (timer > 1 && canChange)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            textbox.gameObject.SetActive(false);
            canChange = false;
        }
		
	}

    void SaySomething()
    {
        //enable textbox
        textbox.gameObject.SetActive(true);
        //animate text (stop all coroutines, in case another event triggers a box)
        StopCoroutine(animator);

        animator = AnimateText();
        StartCoroutine(animator);
        //set timer to disable the box after all text is visible

        timer = 5;
        canChange = true;
    }

    IEnumerator AnimateText()
    {
        int i = 0;
        string temp = "";

        while(i < text.Length)
        {
            temp += text[i++];
            yield return new WaitForSecondsRealtime(.05f);
        }
    }
}
