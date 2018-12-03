using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGameMenu : MonoBehaviour {
	
    void Awake()
    {
        if (!GameManager.isNewGame)
        {
            Destroy(this.gameObject);
        }
        else
            Time.timeScale = 0;
    }
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Pause"))
        {
            GameManager.isNewGame = false;
            GameManager.counter++;
            Save.SaveNow();
            Time.timeScale = 1;
            Destroy(this.gameObject);
        }
	}
}
