using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameQuit : MonoBehaviour {

	public void OnClick()
    {
        Save.SaveNow();
        Application.Quit();
    }
}
