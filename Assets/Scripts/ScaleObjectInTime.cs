using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleObjectInTime : MonoBehaviour
{

    public SpriteRenderer GoodButton;
    public SpriteRenderer BadButton;
    public SpriteRenderer buttonEnable;

    float initTime = 0.5f;
    
    bool errorTime = false;

    float timer = 0;

    private void Start()
    {
        GoodButton.enabled = false;
        BadButton.enabled = false;
    }

    private void Update()
    {
        if (errorTime)
        {
            timer += Time.deltaTime;

            if (timer >= initTime)
            {
                OffBadButtoon();
                errorTime = false;
                timer = 0;
            }
            else
            {
                if (!BadButton.enabled)
                {
                    BadButton.enabled = true;
                }
            }
        }
    }

    public void OffBadButtoon()
    {
        if (BadButton.enabled)
        {
            BadButton.enabled = false;
        }
    }

    public void OffGoodButton()
    {
        if (GoodButton != null)
        {
            GoodButton.enabled = false;
        }
    }
    public void OnGoodButton()
    {
        if (GoodButton != null)
        {
            GoodButton.enabled = true;
        }
    }

    public void ErrorButton()
    {
        errorTime = true;
    }
}