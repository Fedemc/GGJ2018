using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeManager : MonoBehaviour
{
    public Sprite[] imagesToLoad;

    public GloboCombo[] globosCombo;

    int[] arrayButtons;

    public int[] CurrentCode;

    

    public int CodigosAcertadosP1;

    public int CodigosAcertadosP2;

    private float WaitingTime = 0.4f;

    private float timer = 0f;

    private int CurrentState = 0;
    private const int STATE_Fight = 0;
    private const int STATE_WaitingForClash = 1;
    private const int STATE_Clash = 2;

    private LevelManager lvlManager;


    // Use this for initialization
    void Start()
    {

		SetState (STATE_Fight);
        timer = 0f;

        CodigosAcertadosP1 = 0;
        CodigosAcertadosP2 = 0;

        lvlManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
	{

		timer += Time.deltaTime;
		if (CurrentState == STATE_Fight)
		{

			if (CodigosAcertadosP1 >= CurrentCode.Length) 
			{
				Debug.Log ("Gano player 1");
				SetState (STATE_Fight);
                //Restarle vida al P2
                lvlManager.SubstractLife(2);
            }

			if (CodigosAcertadosP2 >= CurrentCode.Length) 
			{
				Debug.Log ("Gano player 2");
				SetState (STATE_Fight);
                //Restarle vida al P1
                lvlManager.SubstractLife(1);
            }
        }
	}


    public void GetCode(int aCantButtons)
    {
        arrayButtons = new int[aCantButtons];

        for (int i = 0; i < arrayButtons.Length; i++)
        {
            arrayButtons[i] = Random.Range(0, 4);
        }

        CurrentCode = arrayButtons;
        CodigosAcertadosP1 = 0;
        CodigosAcertadosP2 = 0;
    }

    public void SetNewGloboCombo()
    {

        Sprite[] temp = new Sprite[arrayButtons.Length];

        for (int i = 0; i < temp.Length; i++)
        {
            temp[i] = imagesToLoad[arrayButtons[i]];
        }

        for (int i = 0; i < globosCombo.Length; i++)
        {
            globosCombo[i].SetComboImage(temp);
            globosCombo[i].SetTransparencySprite();
        }
    }

    public void AcertoPlayer(int aPlayerId)
    {
        if (aPlayerId == 1)
        {
            
            globosCombo[0].SetCorrectButton(CodigosAcertadosP1);
            CodigosAcertadosP1++;
        }
        else
        {
            globosCombo[1].SetCorrectButton(CodigosAcertadosP2);
            CodigosAcertadosP2++;
        }
    }

    public void FalloPlayer(int aPlayerId)
    {
        Debug.Log("Fallaste, Vuelve a empezar");

        if (aPlayerId == 1)
        {
            CodigosAcertadosP1 = 0;
            globosCombo[0].SetTransparencySprite();
        }
        else
        {
            CodigosAcertadosP2 = 0;
            globosCombo[1].SetTransparencySprite();
        }
    }


    private void SetState(int aState)
    {
        timer = 0f;
        CurrentState = aState;

		if (CurrentState == STATE_Fight)
		{
			GetCode(4);
			SetNewGloboCombo();
			CodigosAcertadosP1 = 0;
			CodigosAcertadosP2 = 0;
		}

		if (CurrentState == STATE_WaitingForClash)
		{

		}

    }
}
