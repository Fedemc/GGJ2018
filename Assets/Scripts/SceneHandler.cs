﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneHandler : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void LoadMainStage()
    {
        SceneManager.LoadScene(1);
    }

    void QuitGame()
    {
        Application.Quit();
    }
}