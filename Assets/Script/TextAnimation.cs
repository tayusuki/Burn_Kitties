using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextAnimation : MonoBehaviour {

    Text text;
    Color color;
	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        color = text.color;
	}
	
	// Update is called once per frame
	void Update () {
        text.color = new Color(color.r, color.g, color.b, Mathf.Lerp(0, 1, Mathf.PingPong(Time.unscaledTime, 1)));
	}
}
