using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelVictory : MonoBehaviour {

    // Attach to trigger volume

    // Need to call the function


    public int parNumberOfKitties;
    public int level;
    public int currentNumberOfKitties;

    public Text hud;
    public GameObject panel;

	internal void WonLevel()
    {
        if(level + 1 < GameManager.levels.Length) GameManager.levels[level + 1] = true;
        if(currentNumberOfKitties > parNumberOfKitties)
        {
            GameManager.extras[level] = currentNumberOfKitties - parNumberOfKitties;
        }
        Save.SaveNow();

        //Change this to whatever the scene number is for the loading scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
