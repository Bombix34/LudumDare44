﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlazonPanel : MonoBehaviour
{
    public BlazonManager BlazonManager;
    public Image UpperLeft;
    public Image UpperRight;
    public Image LowerLeft;
    public Image LowerRight;
    public Image Motif;
    // Start is called before the first frame update
    public void UpdateBlazon()
    {
        UpperLeft.color = BlazonManager.UpperLeft;
        UpperRight.color = BlazonManager.UpperRight;
        LowerLeft.color = BlazonManager.LowerLeft;
        LowerRight.color = BlazonManager.LowerRight;
        Motif.color = BlazonManager.MotifColor;
        Motif.sprite = BlazonManager.Motif;
    }
}
