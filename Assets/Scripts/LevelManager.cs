using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    public enum GameState { Jugando, P1_Win, P2_Win, MainMenu }
    public GameState LvlState;
    public GameObject Btns;
    public GameObject WinTxt;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (LvlState == GameState.P1_Win || LvlState == GameState.P2_Win)
        {
            Btns.SetActive(true);
            if (LvlState == GameState.P1_Win)
                WinTxt.GetComponent<Text>().text = "PLAYER 1 WINS!";
            else
                WinTxt.GetComponent<Text>().text = "PLAYER 2 WINS!";
        }
        else
        {
            Btns.SetActive(false);
        }
	}
}
