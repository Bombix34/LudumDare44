﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortraitUI : MonoBehaviour
{
    // mouth -> 0
    // hair -> 1
    // nose -> 2
    // face -> 3
    // eyes -> 4
    // sourcils -> 5
    // barbes -> 6
    // buste -> 7

    public Image mouth;
    public Image hair;
    public Image nose;
    public Image face;
    public Image eyes;
    public Image sourcils;
    public Image barbes;
    public Image buste;

    void Start()
    {
        
    }

    public void SetuptFaceUI(Inheritor concerned)
    {
        /*
        print(concerned.pairSpriteColor[0].Sprite);
        print(concerned.pairSpriteColor[1].Sprite);
        print(concerned.pairSpriteColor[2].Sprite);
        print(concerned.pairSpriteColor[3].Sprite);
        print(concerned.pairSpriteColor[4].Sprite);
        print(concerned.pairSpriteColor[5].Sprite);
        print(concerned.pairSpriteColor[6].Sprite);
        print(concerned.pairSpriteColor[7].Sprite);
        */      


        mouth.sprite = concerned.pairSpriteColor[0].Sprite;
        mouth.color = concerned.pairSpriteColor[0].ElementColor;

        hair.sprite = concerned.pairSpriteColor[1].Sprite;
        hair.color = concerned.pairSpriteColor[1].ElementColor;

        nose.sprite = concerned.pairSpriteColor[2].Sprite;
        nose.color = concerned.pairSpriteColor[2].ElementColor;

        face.sprite = concerned.pairSpriteColor[3].Sprite;
        face.color = concerned.pairSpriteColor[3].ElementColor;

        eyes.sprite = concerned.pairSpriteColor[4].Sprite;
        eyes.color = concerned.pairSpriteColor[4].ElementColor;

        sourcils.sprite = concerned.pairSpriteColor[5].Sprite;
        sourcils.color = concerned.pairSpriteColor[5].ElementColor;

        if (concerned.pairSpriteColor[6].Sprite != null)
            barbes.sprite = concerned.pairSpriteColor[6].Sprite;
        else
            barbes.gameObject.SetActive(false);
        barbes.color = concerned.pairSpriteColor[6].ElementColor;

        buste.sprite = concerned.pairSpriteColor[7].Sprite;
        buste.color = concerned.pairSpriteColor[7].ElementColor;

    }
}