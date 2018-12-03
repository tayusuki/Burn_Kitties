using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGameMenu : MonoBehaviour {
	
    void Start()
    {
        Time.timeScale = 0;
    }
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown(""))
        {
            Time.timeScale = 1;
            Destroy(this);
        }
	}
}
