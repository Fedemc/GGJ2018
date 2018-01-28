using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CodeManager : MonoBehaviour
{
    public Sprite[] imagesToLoad;

    public Transform[] refpositions;

    public GloboCombo[] globosCombo;

    int[] arrayButtons;

    public int[] CurrentCode;

    public GameObject ClashUI;

    


    public int CodigosAcertadosP1;

    public int CodigosAcertadosP2;

    public GameObject RobotP1;
    public GameObject RobotP2;



    private float WaitingTime = 0.8f;

    private float timer = 0f;

    public int CurrentState = 0;
    private const int STATE_Fight = 0;
    private const int STATE_WaitingForClash = 1;
    private const int STATE_Clash = 2;


    private int BackCount = 5;

    private LevelManager lvlManager;

    private bool winPlayer;

    AudioManager audioManager;


    // Use this for initialization
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        SetState(STATE_Fight);
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

                //Debug.Log ("Gano player 1");
                //SetState (STATE_Fight);

                SetState(STATE_WaitingForClash);
            }

            if (CodigosAcertadosP2 >= CurrentCode.Length)
            {

                //	Debug.Log ("Gano player 2");
                // SetState (STATE_Fight);
                SetState(STATE_WaitingForClash);
            }
        }
        if (CurrentState == STATE_WaitingForClash)
        {
            if (timer >= WaitingTime)
            {
                if (CodigosAcertadosP1 > CodigosAcertadosP2)
                {
                    Debug.Log("Gano player 1");
                    RobotP1.GetComponent<RobotHandler>().PunchAnimation();
                    RobotP2.GetComponent<RobotHandler>().HitAnimation();
                    lvlManager.SubstractLife(2);
                    CheckRobotDeath();
                    audioManager.PlayFx("Hit");     //ACA VA EL PIÑAZO!
                }

                else if (CodigosAcertadosP2 > CodigosAcertadosP1)
                {
                    Debug.Log("Gano player 2");
                    RobotP2.GetComponent<RobotHandler>().PunchAnimation();
                    RobotP1.GetComponent<RobotHandler>().HitAnimation();
                    lvlManager.SubstractLife(1);
                    CheckRobotDeath();
                    audioManager.PlayFx("Hit");      //ACA VA EL PIÑAZO!
                }


                SetState(STATE_Fight);
            }
            else if (CodigosAcertadosP1 == CodigosAcertadosP2)
            {

                SetState(STATE_Clash);
            }
        }
        if (CurrentState == STATE_Clash)
        {
            ClashUI.GetComponentInChildren<Text>().text = "" + (BackCount - timer).ToString();

            if (timer >= BackCount)
                SetState(STATE_Fight);

        

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

	public void GetClashCode()//codigo para el clash
	{


		CurrentCode[0] = Random.Range(0, 4);
		Debug.Log (CurrentCode[0]);
		
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
            globosCombo[i].SetCorrectColor(1);
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

    public void AcertoPlayerInClash(int aPlayerId)//clash
    { Debug.Log(aPlayerId + "Player ID");
        if (aPlayerId == 1)
        {

            //Debug.Log("Gano player 1");
            RobotP1.GetComponent<RobotHandler>().PunchAnimation();
            RobotP2.GetComponent<RobotHandler>().HitAnimation();
            //RobotP2.GetComponentInChildren<ParticleSystem>().Play();
            lvlManager.SubstractLife(2);
            audioManager.PlayFx("Hit");
            CheckRobotDeath();

        }
		else
		{
			//Debug.Log("Gano player 2");
			RobotP2.GetComponent<RobotHandler>().PunchAnimation();
			RobotP1.GetComponent<RobotHandler>().HitAnimation();
			//RobotP1.GetComponentInChildren<ParticleSystem>().Play();
			lvlManager.SubstractLife(1);
            audioManager.PlayFx("Hit");
            CheckRobotDeath();
        }
		SetState (STATE_Fight);
	}
	public void FalloPlayerInClash(int aPlayerId)//clash
	{
		if (aPlayerId == 1)
		{

			Debug.Log("fallo en clash el player 1");
			RobotP2.GetComponent<RobotHandler>().PunchAnimation();
			RobotP1.GetComponent<RobotHandler>().HitAnimation();
			//RobotP2.GetComponentInChildren<ParticleSystem>().Play();
			lvlManager.SubstractLife(1);
            audioManager.PlayFx("Hit");
            CheckRobotDeath();
        }
		else
		{
			Debug.Log("fallo en clash el player  2");
			RobotP1.GetComponent<RobotHandler>().PunchAnimation();
			RobotP2.GetComponent<RobotHandler>().HitAnimation();
			//RobotP1.GetComponentInChildren<ParticleSystem>().Play();
			lvlManager.SubstractLife(2);
            audioManager.PlayFx("Hit");
            CheckRobotDeath();
        }
		SetState (STATE_Fight);
	}


    public void FalloPlayer(int aPlayerId)
    {
        Debug.Log("Fallaste, Vuelve a empezar");
        audioManager.PlayFx("ErrorSound");
        if (aPlayerId == 1)
        {
            CodigosAcertadosP1 = 0;
            globosCombo[0].SetCorrectColor(2);
        }
        else
        {
            CodigosAcertadosP2 = 0;
            globosCombo[1].SetCorrectColor(2);
        }
    }


    private void SetState(int aState)
    {
        timer = 0f;
        CurrentState = aState;

        if (CurrentState == STATE_Fight)
        {
            ClashUI.SetActive(false);
            GetCode(4);
            SetNewGloboCombo();
            CodigosAcertadosP1 = 0;
            CodigosAcertadosP2 = 0;
        }

		if (CurrentState == STATE_Clash)//clash
        {
            Debug.Log("Clash");
            ClashUI.SetActive(true);
			GetClashCode ();
			ClashUI.GetComponentInChildren<Image> ().sprite = imagesToLoad [CurrentCode [0]];
			
			Debug.Log ("El current code 0 es : " + CurrentCode[0].ToString());
        }

        if (CurrentState == STATE_Fight)
        {
            winPlayer = false;
        }

        if (CurrentState == STATE_WaitingForClash)
        {
            winPlayer = false;
            audioManager.PlayFx("CompleteCombo");
        }
    }

    private void CheckRobotDeath()      //Verifica si alguno de los robots esta en 0 vida y setea la animacion de muerte
    {
        if (lvlManager.GetLifeP1() == 0)
        {
            RobotP1.GetComponent<RobotHandler>().DieAnimation();
            Invoke("Player2WinAudio", 0.5f);
        }
        else
        {
            if (lvlManager.GetLifeP2() == 0)
            {
                RobotP2.GetComponent<RobotHandler>().DieAnimation();
                Invoke("Player1WinAudio", 0.5f);
            }
        }
    }

    private void Player1WinAudio()
    {
        FindObjectOfType<AudioManager>().PlayFx("P1Wins");
        
    }

    private void Player2WinAudio()
    {
        FindObjectOfType<AudioManager>().PlayFx("P2Wins");
    }
}
