using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    // Does not need to be attached

    //Need to figure out how this applies to the scene number in the future. :)
    internal static bool[] levels = new bool[] { true, true, false, false, false, false, false, false, false, false, false, false };
    internal static int[] extras = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    internal static bool isNewGame = true;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
