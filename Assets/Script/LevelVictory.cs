using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelVictory : MonoBehaviour {

    // Attach to player

    // Need to call the function


    public int parNumberOfKitties;
    public int level;
    public int currentNumberOfKitties;

    public GameObject panel;

	internal void WonLevel()
    {
        if(level + 1 < GameManager.levels.Length) GameManager.levels[level + 1] = true;
        if(currentNumberOfKitties > parNumberOfKitties)
        {
            GameManager.extras[level] = currentNumberOfKitties - parNumberOfKitties;
        }
        Save.SaveNow();

        if(level == 11)
        {
            SceneManager.LoadScene("LevelSelector");
        }

        //Change this to whatever the scene number is for the loading scene
        Time.timeScale = 0;
        panel.SetActive(true);
        GameManager.hasWon = true;
    }
}
