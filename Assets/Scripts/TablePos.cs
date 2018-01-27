using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TablePos : MonoBehaviour
{
    public enum tableBtn { btnA, btnB, btnX, btnY };
    private tableBtn PosAssignedButton;


    public void SetAssignedButton(int btnIndex)
    {
        switch(btnIndex)
        {
            case 0:
                PosAssignedButton = tableBtn.btnA;
                break;

            case 1:
                PosAssignedButton = tableBtn.btnB;
                break;

            case 2:
                PosAssignedButton = tableBtn.btnX;
                break;

            case 3:
                PosAssignedButton = tableBtn.btnY;
                break;
        }
    }

    public tableBtn GetPosAssignedButton()
    {
        return PosAssignedButton;
    }

}
