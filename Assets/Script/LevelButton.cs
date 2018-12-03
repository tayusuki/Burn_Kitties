using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour {

    // Attach to Level Selector Buttons

    public int levelNumber;
    public string levelSelector;
    public bool isLocked = false;
    public int maxExtras = 10;

    void Start()
    {
        if (GameManager.levels[levelNumber] && levelNumber != 99)
        {
            isLocked = false;
            GetComponentInChildren<Text>().text = GameManager.extras[levelNumber] + "/" + maxExtras;
        }
        else
        {
            isLocked = true;
            GetComponentInChildren<Text>().text = GameManager.extras[levelNumber] + "/" + maxExtras;
            GetComponent<Button>().interactable = false;
        }
    }

	public void OnClick()
    {
        SceneManager.LoadScene(levelNumber.ToString());
    }

    public void OnClick2()
    {
        SceneManager.LoadScene(levelSelector);
    }
}
