using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPause : MonoBehaviour {

    public GameObject pauseMenu;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Pause"))
        {
            if (pauseMenu.activeInHierarchy)
            {
                pauseMenu.SetActive(false);
            }
            else
                pauseMenu.SetActive(true);
        }
	}
}
