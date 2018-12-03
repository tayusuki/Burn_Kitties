using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour {

    // Attach to player

    public List<string> randomSayings = new List<string>();
    public List<string> whenCatsAreSacrificed = new List<string>();
    public List<string> whenCatsAreThrown = new List<string>();
    public List<string> whenCatsAreGrabbed = new List<string>();

    float counter = 0;

    void Update()
    {
        counter += Time.deltaTime;

        if(counter >= 5)
        {
            SaySomething(1);
            counter = 0;
        }
    }

    internal void SaySomething(int number)
    {
        if (Random.Range(0, 10) > 5)
            MakeSelection(number);
    }

     void MakeSelection(int list)
    {

        switch (list)
        {
            case 1:
                {
                    GetComponentInChildren<TextboxBehavior>(true).text = randomSayings[Random.Range(0, randomSayings.Count)];
                    GetComponentInChildren<TextboxBehavior>(true).SaySomething();
                    break;
                }
            case 2:
                {
                    GetComponentInChildren<TextboxBehavior>(true).text = whenCatsAreSacrificed[Random.Range(0, whenCatsAreSacrificed.Count)];
                    GetComponentInChildren<TextboxBehavior>(true).SaySomething();
                    break;
                }
            case 3:
                {
                    GetComponentInChildren<TextboxBehavior>(true).text = whenCatsAreThrown[Random.Range(0, whenCatsAreThrown.Count)];
                    GetComponentInChildren<TextboxBehavior>(true).SaySomething();
                    break;
                }
            case 4:
                {
                    GetComponentInChildren<TextboxBehavior>(true).text = whenCatsAreGrabbed[Random.Range(0, whenCatsAreGrabbed.Count)];
                    GetComponentInChildren<TextboxBehavior>(true).SaySomething();
                    break;
                }
            default:
                {
                    break;
                }
        }
    }

    // Under certain conditions, the textbox near the player will display text
    // Determine these conditions and change the text TextboxBehaviour.text
    // Call TextboxBehaviour.SaySomething()
}
