using System.Collections;
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

    void Start()
    {
        weddingPanel.SetActive(false);
        validButton.SetActive(false);
        ui = weddingPanel.GetComponent<WeddingInheritorUI>();
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

            ResetWedding();
            ui.gameObject.SetActive(false);
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
        }
        else
        {
            monneyVal *= -1;
        }
        GameManager.Instance.GoldCoins += monneyVal;
        GameManager.Instance.InfluencePoints += influenceVal;
        if (isStrongSex)
            Createchildren(concerned, affinityVal);
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
        }
        DescentContainer.Instance.UpdateView();
    }
            ui.gameObject.SetActive(false);
            inheritor.Spouse.Manager.Face.DieFeedback();
        }
    }
}
