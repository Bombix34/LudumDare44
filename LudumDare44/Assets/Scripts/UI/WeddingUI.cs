﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeddingUI : Singleton<WeddingUI>
{
    public GameObject weddingPanel;
    WeddingInheritorUI ui;

    public PretendantManager pretendantUI;

    public PortraitUI portraitConcerned;

    public GameObject validButton;

    public Inheritor inheritor;
    public Inheritor choice;

    public CharacterPool poolCharacter;

    WeddingManager weddingManager;

    void Start()
    {
        weddingPanel.SetActive(false);
        validButton.SetActive(false);
        ui = weddingPanel.GetComponent<WeddingInheritorUI>();
        weddingManager = GameManager.Instance.GetComponent<WeddingManager>();
    }

    public void ShowWeddingPanel(bool isAlive, Inheritor concerned, List<Inheritor>pretendants)
    {
        inheritor = concerned;
        weddingPanel.SetActive(isAlive);
        ui.CreateView(concerned);


        portraitConcerned.SetuptFaceUI(concerned);

        pretendantUI.LaunchPretendantUI(pretendants, concerned);
    }

    public void LaunchValidation(GameObject pretendantChoose)
    {
        SoundManager.instance.PlaySound(1);
        pretendantUI.ResetPretendantColors();
        pretendantChoose.GetComponent<Image>().color = Color.green;
        choice = pretendantChoose.GetComponent<WeddingPretendantUI>().Current;
        validButton.SetActive(true);
    }

    public void ResetWedding()
    {
        pretendantUI.ResetPretendantColors();
        choice = null;
        validButton.SetActive(false);
    }

    public void EndWedding()
    {
        if((inheritor!=null)&&(choice!=null))
        {
            inheritor.Spouse = choice;
            choice.Spouse = inheritor;
            if (inheritor.isWomen==GameManager.Instance.IsWomenStrongSex)
            {//SEXE FORT QUI SE MARRIE
                choice.FamilyName = inheritor.FamilyName;
            }
            else
            {//SEXE FAIBLE QUI SE MARRIE
                inheritor.FamilyName = choice.FamilyName;
                choice.IsAlive = false;
                inheritor.IsAlive = false;
            }

            inheritor.Manager.GetComponent<CoupleManager>().SetupSecondCharacter(choice);
            inheritor.Manager.GetComponent<CoupleManager>().currentState = CoupleManager.CoupleState.couple;
            inheritor.Manager.GetComponent<CoupleManager>().UpdateCoupleInterface();

            DescentContainer.Instance.UpdateView();

            inheritor.Spouse.Manager.Face.InitWithValue();

            UpdateValue(inheritor, choice);

            choice.Manager.Init(choice);
            inheritor.Manager.UpdateBlazon();

            ui.gameObject.SetActive(false);
            inheritor.Spouse.Manager.Face.DieFeedback();

            weddingManager.RemoveFromPool(choice);

            ResetWedding();
            ui.gameObject.SetActive(false);

            GameManager.Instance.FinishWedding();
        }
    }

    public void UpdateValue(Inheritor concerned, Inheritor pretendant)
    {
        bool isStrongSex = (concerned.isWomen == GameManager.Instance.IsWomenStrongSex);
        int monneyVal = pretendant.MonnaieValue + concerned.MonnaieValue;
        int influenceVal = pretendant.InfluenceValue + concerned.InfluenceValue;
        int affinityVal = Mathf.FloorToInt((pretendant.Attirance + concerned.Attirance) / 2);
        if (isStrongSex)
        {
            influenceVal *= -1;
            Createchildren(concerned, affinityVal);
        }
        else
        {
            monneyVal *= -1;
            concerned.IsGone = true;
            pretendant.IsGone = true;
        }
        GameManager.Instance.GoldCoins += monneyVal;
        GameManager.Instance.InfluencePoints += influenceVal;
    }

    public void Createchildren(Inheritor concerned,int val)
    {
        for(int i=0;i<val;i++)
        {
           concerned.Childrens.Add(poolCharacter.GetCharacterWithoutFace(Random.value > 0.5f));
           concerned.Childrens[i].FamilyName = concerned.FamilyName;
            concerned.Childrens[i].NotBornYet = true;
            concerned.Childrens[i].IsAlive = true;
            concerned.Childrens[i].Age = (int)Random.Range(1f,7f);
            concerned.Childrens[i].Parent = concerned;
        }
        DescentContainer.Instance.UpdateView();
    }

    public void PlayClickSound()
    {
        SoundManager.instance.PlaySound(1);
    }
}
