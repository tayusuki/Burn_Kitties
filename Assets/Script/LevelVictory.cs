using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelVictory : MonoBehaviour {

    public int parNumberOfKitties;
    public int level;

	internal void WonLevel()
    {
        if(level + 1 < GameManager.levels.Length) GameManager.levels[level + 1] = true;
        Save.SaveNow();

        //Change this to whatever the scene number is for the loading scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
