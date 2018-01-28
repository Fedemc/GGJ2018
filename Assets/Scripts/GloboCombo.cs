using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GloboCombo : MonoBehaviour
{

    public SpriteRenderer[] spritesCombo;
    public ScaleObjectInTime[] ButtonToScale;

    float timer;
    public float growFactor = 0.36f;
    bool noMeAgrande;

    // Use this for initialization
    void Start()
    {
        SetCorrectColor(1);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetComboImage(Sprite[] aNewCombo)
    {
        for (int i = 0; i < spritesCombo.Length; i++)
        {
            spritesCombo[i].sprite = aNewCombo[i];
        }
    }


    public void SetCorrectColor(int aCodeError)
    {
        if (aCodeError == 1)
        {
            for (int i = 0; i < spritesCombo.Length; i++)
            {
                spritesCombo[i].color = new Color32(255, 255, 255, 125);
                ButtonToScale[i].OffGoodButton();
            }
        }
        else if (aCodeError == 2)
        {
            for (int i = 0; i < spritesCombo.Length; i++)
            {
                spritesCombo[i].color = new Color32(255, 255, 255, 125);
                ButtonToScale[i].OffGoodButton();
                ButtonToScale[i].ErrorButton();
                
            }
        }
    }

    public void SetCorrectButton(int aIndexButton)
    {
        spritesCombo[aIndexButton].color = new Color32(255, 255, 255, 255);
        ButtonToScale[aIndexButton].OnGoodButton();
    }
}
