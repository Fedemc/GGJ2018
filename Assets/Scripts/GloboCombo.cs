using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GloboCombo : MonoBehaviour
{

    public SpriteRenderer[] spritesCombo;

    // Use this for initialization
    void Start()
    {
        SetTransparencySprite();
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


    public void SetTransparencySprite()
    {
        for (int i = 0; i < spritesCombo.Length; i++)
        {
            spritesCombo[i].color = new Color32(255, 255, 255, 125);
        }
    }

    public void SetCorrectButton(int aIndexButton)
    {
        spritesCombo[aIndexButton].color = new Color32(255, 255, 255, 255);
    }
}
