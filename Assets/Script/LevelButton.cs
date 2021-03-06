﻿using System.Collections;
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
    public bool isConfirmation;

    void Start()
    {
        if (!isConfirmation)
        {
            if (GameManager.levels[levelNumber] && levelNumber != 99)
            {
                isLocked = false;
                GetComponentInChildren<Text>().text = GameManager.extras[levelNumber].ToString();
            }
            else
            {
                isLocked = true;
                GetComponentInChildren<Text>().text = GameManager.extras[levelNumber].ToString();
                GetComponent<Button>().interactable = false;
            }
        }
    }

	public void OnClick()
    {
        if (GameObject.FindObjectOfType<LevelVictory>() != null && GameObject.FindObjectOfType<LevelVictory>().level == 11)
            GameManager.beatGame = true;
        SceneManager.LoadScene(levelNumber.ToString());
    }

    public void OnClick2()
    {
        SceneManager.LoadScene(levelSelector);
    }
}
