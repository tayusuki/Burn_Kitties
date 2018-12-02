using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour {

    // Attach to player

    public List<string> random = new List<string>();
    public List<string> whenCatsAreSacrificed = new List<string>();
    public List<string> victory = new List<string>();

    // Under certain conditions, the textbox near the player will display text
    // Determine these conditions and change the text TextboxBehaviour.text
    // Call TextboxBehaviour.SaySomething()
}
