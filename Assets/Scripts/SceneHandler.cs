using System.Collections;
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

    public void LoadMainStage()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadMainStageFromMenu()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            FindObjectOfType<AudioManager>().PlayFx("MenuStart");
            Invoke("LoadMainStage", 2f);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
