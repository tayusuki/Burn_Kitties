using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ConfirmationPanel : MonoBehaviour {

    EventSystem eventS;
    public GameObject button;

	// Use this for initialization
	void Start () {
        GameObject.Find("EventSystem").GetComponent<EventSystem>();
        eventS.SetSelectedGameObject(button);
	}
	
	// Update is called once per frame
	void Update () {
        if ((Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Mouse1) || Input.GetKeyDown(KeyCode.Mouse3)) && GameManager.hasWon)
        {
            eventS.SetSelectedGameObject(button);
        }
    }
}
