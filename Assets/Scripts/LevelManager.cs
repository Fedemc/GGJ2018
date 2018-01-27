using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    public enum GameState { Jugando, P1_Win, P2_Win, MainMenu }
    public GameState LvlState;
    public GameObject Btns;
    public GameObject WinTxt;

    public SpriteRenderer[] P1_CellArray;
    public SpriteRenderer[] P2_CellArray;

    private int LifeP1 = 3, LifeP2 = 3;

	// Use this for initialization
	void Start ()
    {
		//Setear arrays de celdas vida todos ON
        for(int i=0; i<P1_CellArray.Length;i++)
        {
            P1_CellArray[i].enabled = true;
            P2_CellArray[i].enabled = true;
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        CheckLife();
        PlayerWin();
    }

    private void CheckLife()
    {
        if (LifeP1 == 0)
        {
            LvlState = GameState.P2_Win;
        }
        else
        {
            if (LifeP2 == 0)
            {
                LvlState = GameState.P1_Win;
            }
        }
    }

    private void PlayerWin()
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

    public void SubstractLife(int playerIndex)
    {
        if (playerIndex == 1)
        {
            LifeP1--;
            //Apagar una celda P1
            P1_CellArray[LifeP1].enabled = false;
        }
            
        else
        {
            LifeP2--;
            //Apagar una celda P2
            P2_CellArray[LifeP2].enabled = false;
        }

    }
}
