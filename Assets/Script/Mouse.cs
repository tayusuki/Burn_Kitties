using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Mouse : MonoBehaviour {

	void Start () {
        DontDestroyOnLoad(this);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Mouse1) || Input.GetKeyDown(KeyCode.Mouse3)) && !GameManager.hasWon)
            
        {
            GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("EventSystem").GetComponent<EventSystem>().firstSelectedGameObject);
        }

        if (Input.GetButtonDown("Pause"))
        {
            GameManager.counter++;
        }
    }
}
