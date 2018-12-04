using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuAudio : MonoBehaviour {

    public void OnDeselect()
    {
        GameObject.Find("ButtonSound").GetComponent<AudioSource>().Play();
    }
}
