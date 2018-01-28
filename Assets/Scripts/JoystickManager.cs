using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class JoystickManager : MonoBehaviour
{
    public PlayerIndex[] playerIndex;

    public bool control1 = false, control2 = false, control3 = false, control4 = false;
    private PlayerIndex pi;
    public PlayerIndex pi1, pi2, pi3, pi4;
    private GamePadState gp;


    private void Start()
    {
        playerIndex = new PlayerIndex[4];
        CargarJoysticksActivos();
    }

    public void CargarJoysticksActivos()
    {
        for (int i = 0; i < 4; i++)
        {
            //Guardo temporalmente un playerIndex del jugador i 
            pi = (PlayerIndex)i;

            //Guardo el estado actual del control
            gp = GamePad.GetState(pi);


            switch (i)
            {
                case 0:
                    //gp.IsConnected da un false o un true, creo que es algo obvio :P
                    control1 = gp.IsConnected;                    
                    //se guarda el playerIndex por si se va a usar en el script NewBehaviourScript(se me olvido ponerle nombre lol)
                    pi1 = pi;
                    break;

                case 1:
                    control2 = gp.IsConnected;
                    pi2 = pi;
                    break;

                case 2:
                    control3 = gp.IsConnected;
                    pi3 = pi;
                    break;

                case 3:
                    control4 = gp.IsConnected;
                    pi4 = pi;
                    break;
            }
        }
        GetPlayerOneJoy();
        GetPlayerTwoJoy();
    }

    public void GetPlayerOneJoy()
    {
        if (control1)
        {
            playerIndex[0] = pi1;
        }
        else if (control2)
        {
            playerIndex[0] = pi2;
        }
        else if (control3)
        {
            playerIndex[0] = pi3;
        }
        else if (control4)
        {
            playerIndex[0] = pi4;
        }
    }
    public void GetPlayerTwoJoy()
    {
        if (control1 && playerIndex[0] != pi1)
        {
            playerIndex[1] = pi1;
        }
        else if (control2 && playerIndex[0] != pi2)
        {
            playerIndex[1] = pi2;
        }
        else if (control3 && playerIndex[0] != pi3)
        {
            playerIndex[1] = pi3;
        }
        else if (control4 && playerIndex[0] != pi4)
        {
            playerIndex[1] = pi4;
        }
    }
}
