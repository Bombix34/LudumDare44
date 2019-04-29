﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeddingUI : Singleton<WeddingUI>
{
    public GameObject weddingPanel;
    WeddingInheritorUI ui;

    public PretendantManager pretendantUI;

    public PortraitUI portraitConcerned;

    void Start()
    {
        weddingPanel.SetActive(false);
        ui = weddingPanel.GetComponent<WeddingInheritorUI>();
    }

    public void ShowWeddingPanel(bool isAlive, Inheritor concerned, List<Inheritor>pretendants)
    {
        weddingPanel.SetActive(isAlive);
        ui.CreateView(concerned);


        portraitConcerned.SetuptFaceUI(concerned);


        pretendantUI.LaunchPretendantUI(pretendants, concerned.Attirance);
    }


}
