using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour {

    // Attach to Level Selector Buttons

    public int levelNumber;
    public string levelSelector;
    public bool isLocked = false;

    void Start()
    {
        if (GameManager.levels[levelNumber])
            isLocked = false;
        else
            isLocked = true;
    }

	public void OnClick()
    {
        Save.SaveNow();
        SceneManager.LoadScene(levelNumber.ToString());
    }

    public void OnClick2()
    {
        Save.SaveNow();
        SceneManager.LoadScene(levelSelector);
    }
}
