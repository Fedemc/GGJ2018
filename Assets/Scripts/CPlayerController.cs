using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayerController : MonoBehaviour
{
    public Transform[] Points;
    
    private CodeManager refCodeMaganer;

    private TableManager TableAssigned;


    public int CurrentPoint = 0;

    private float timer = 0f;

    private float CoolDownToMove = 0.01f;

    private int CurrentState = 0;
    private const int STATE_Stay = 0;
    private const int STATE_Moving = 1;

	public int? LastButton;



    enum p_state { awaitingMove, moved };
    private p_state playerState;
    [SerializeField] float deadZone = 0.8f;
    private CPlayerController playerContr;
    private LevelManager lvlManager;
    


    public int playerId;

    // Use this for initialization
    void Start()
    {
        refCodeMaganer = FindObjectOfType<CodeManager>();

        playerState = p_state.awaitingMove;
        playerContr = GetComponent<CPlayerController>();

        CurrentPoint = 0;
        transform.position = Points[0].transform.position;
        lvlManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
		
        timer += Time.deltaTime;

//        if(lvlManager.LvlState == LevelManager.GameState.Jugando)
//        {
//            
//        }        

        if (CurrentState == STATE_Stay)
        {
			Move();
			GetImputJoy();

        }
        if (CurrentState == STATE_Moving)
        {
            if (timer >= CoolDownToMove)
                SetState(STATE_Stay);
        }
    }

    public void SetLastButton(int aLastButton)
    {
        LastButton = aLastButton;

        int tmp = 0;
        if (playerId == 1)
        {
            tmp = refCodeMaganer.CodigosAcertadosP1;
        }
        else
        {
            tmp = refCodeMaganer.CodigosAcertadosP2;
        }

		if (refCodeMaganer.CurrentState == 2) 
		{
			
			if (LastButton == refCodeMaganer.CurrentCode [0]) 
			{
				Debug.Log ("CLASH WIN");
				refCodeMaganer.AcertoPlayerInClash (playerId);

			} 
			else if
				(LastButton != null && LastButton != refCodeMaganer.CurrentCode [0]) 
			{
				refCodeMaganer.FalloPlayerInClash (playerId);
			}
		
		}
		else if (LastButton == refCodeMaganer.CurrentCode[0 + tmp] && CurrentPoint == refCodeMaganer.CurrentCode[0 + tmp])
        {
            Debug.Log("Acertaste el botton  y estas en la casilla correcta");
            refCodeMaganer.AcertoPlayer(playerId);
        }
		else
        {
            refCodeMaganer.FalloPlayer(playerId);
        }
		Debug.Log (LastButton);

    }

	public void CleanLastButton()
	{
		LastButton = null;
	}
    public void ChangePositionDown()
    {
        SetState(STATE_Moving);

        CurrentPoint++;
        if (CurrentPoint > 3)
            CurrentPoint = 3;

        transform.position = Points[CurrentPoint].transform.position;
    }

    public void ChangePositionUp()
    {
        CurrentPoint--;
        if (CurrentPoint < 0)
            CurrentPoint = 0;
        transform.position = Points[CurrentPoint].transform.position;
    }

    public void GetImputJoy()
    {
        //Ifs de Input
        if (Input.GetButtonDown(string.Format("ButtonA_P{0}", playerId)))
        {
            //Debug.Log("Presionado boton A en player " + playerId);
            //Obtener pos de la mesa
            playerContr.SetLastButton(0);
            //Verificar que el botón coincida con el botón de la mesa
        }

        if (Input.GetButtonDown(string.Format("ButtonB_P{0}", playerId)))
        {
            //Debug.Log("Presionado boton B en player " + playerId);

            playerContr.SetLastButton(1);

        }

        if (Input.GetButtonDown(string.Format("ButtonX_P{0}", playerId)))
        {
            //Debug.Log("Presionado boton X en player " + playerId);

            playerContr.SetLastButton(2);

        }

        if (Input.GetButtonDown(string.Format("ButtonY_P{0}", playerId)))
        {
            //Debug.Log("Presionado boton Y en player " + playerId);
            playerContr.SetLastButton(3);
        }
    }

    private void SetState(int aState)
    {
        timer = 0f;
        CurrentState = aState;

        if (CurrentState == STATE_Stay)
        {
        }

        if (CurrentState == STATE_Moving)
        {
        }
        
    }

    private void Move()
    {
        var verticalValue = Input.GetAxis(string.Format("Vertical_P{0}", playerId));
        //Debug.Log(verticalValue);

        if (playerState == p_state.awaitingMove) //Si estoy listo para moverme
        {
            if (verticalValue < -deadZone)
            {
                //Mover hacia arriba
                playerContr.ChangePositionUp();
                //Refrescar pos en la mesa
                //cambiar el estado
                playerState = p_state.moved;
            }
            else
            {
                if (verticalValue > deadZone)
                {
                    //Mover hacia abajo
                    playerContr.ChangePositionDown();
                    //cambiar el estado
                    playerState = p_state.moved;
                }
            }
        }
        else //Si ya me movi tengo que esperar a que vuelva el axis a neutro
        {
            if (verticalValue < deadZone && verticalValue > -deadZone)
            {
                playerState = p_state.awaitingMove;
                //Debug.Log("Entered deadzone");
            }
        }
    }

    public void ButtonPressed(int btnIndex)
    {

    }
}