using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XInputDotNetPure;


public class LevelManager : MonoBehaviour
{
    public enum GameState { Jugando, P1_Win, P2_Win, MainMenu }
    public GameState LvlState;
    public GameObject Btns;
    public GameObject P1WinText;
    public GameObject ParticlesP1;
    public GameObject ParticlesP2;
    public GameObject P2WinText;

    public SpriteRenderer[] P1_CellArray;
    public SpriteRenderer[] P2_CellArray;

    private int LifeP1 = 3, LifeP2 = 3;

    bool POneVibration;
    bool PTwoVibration;

    JoystickManager joyManager;

    // Use this for initialization
    void Start()
    {
        joyManager = GetComponent<JoystickManager>();
        //Setear arrays de celdas vida todos ON
        for (int i = 0; i < P1_CellArray.Length; i++)
        {
            P1_CellArray[i].enabled = true;
            P2_CellArray[i].enabled = true;
        }
        FindObjectOfType<AudioManager>().PlaySound("StageMusic");
    }

    // Update is called once per frame
    void Update()
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
            {
                P1WinText.SetActive(true);
                ParticlesP1.SetActive(true);
                //FindObjectOfType<AudioManager>().PlayFx("P1Wins");
            }
                
            else
            {
                P2WinText.SetActive(true);
                ParticlesP2.SetActive(true);
                //FindObjectOfType<AudioManager>().PlayFx("P2Wins");
            }
                
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
            VibrateJoy(playerIndex);
        }
        else
        {
            LifeP2--;
            //Apagar una celda P2
            P2_CellArray[LifeP2].enabled = false;
            VibrateJoy(playerIndex);
        }
    }

    private void VibrateJoy(int aPlayer)
    {
        if (aPlayer == 1 && !POneVibration)
        {
            POneVibration = true;
            GamePad.SetVibration(joyManager.playerIndex[0], 0.8f, 0.8f);
            Invoke("StopVibrate", 0.5f);

        }
        else if (aPlayer == 2 && !PTwoVibration)
        {
            PTwoVibration = true;
            GamePad.SetVibration(joyManager.playerIndex[1], 0.5f, 0.5f);
            Invoke("StopVibrate", 0.5f);
        }
    }

    private void StopVibrate()
    {
        if (POneVibration)
        {
            GamePad.SetVibration(joyManager.playerIndex[0], 0, 0);
            POneVibration = false;
        }
        if (PTwoVibration)
        {
            GamePad.SetVibration(joyManager.playerIndex[1], 0, 0);
            PTwoVibration = false;
        }
    }

    public int GetLifeP1()
    {
        return LifeP1;
    }

    public int GetLifeP2()
    {
        return LifeP2;
    }
}
