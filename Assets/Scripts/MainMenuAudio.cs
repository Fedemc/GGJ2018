using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuAudio : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        FindObjectOfType<AudioManager>().PlaySound("MenuMusic");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
