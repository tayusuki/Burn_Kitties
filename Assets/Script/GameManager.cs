﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    // Does not need to be attached

    //Need to figure out how this applies to the scene number in the future. :)
    internal static bool[] levels = new bool[] { true, false, false, false, false, false, false, false, false, false, false, false };
    internal static int[] extras = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    internal static bool isNewGame = true;
    internal static bool hasWon = false;
    internal static int counter = 0;
    internal static bool beatGame = false;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
