using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGameMenu : MonoBehaviour {
	
    void Start()
    {
        if (!GameManager.isNewGame)
            Destroy(this.gameObject);
        Time.timeScale = 0;
    }
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Pause"))
        {
            GameManager.isNewGame = false;
            Save.SaveNow();
            Time.timeScale = 1;
            Destroy(this.gameObject);
        }
	}
}
