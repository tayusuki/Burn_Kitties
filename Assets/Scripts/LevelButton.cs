using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour {

    public int levelNumber;
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
        SceneManager.LoadScene(levelNumber);
    }
}
