using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuPause : MonoBehaviour {

    public GameObject pauseMenu;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Pause") && !GameManager.hasWon && GameManager.counter > 1)
        {
            if (!pauseMenu.activeInHierarchy && !GameManager.isNewGame)
            {
                pauseMenu.SetActive(true);
                GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("EventSystem").GetComponent<EventSystem>().firstSelectedGameObject);
                Time.timeScale = 0;
            }
            else
            {
                pauseMenu.SetActive(false);
                Time.timeScale = 1;
            }
        }
	}
}
