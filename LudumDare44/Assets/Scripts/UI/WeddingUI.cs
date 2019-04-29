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

        pretendantUI.LaunchPretendantUI(pretendants, concerned.Attirance);
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
            choice.UpdateBlazon();
            inheritor.UpdateBlazon();

            inheritor.Manager.GetComponent<CoupleManager>().SetupSecondCharacter(choice);
            inheritor.Manager.GetComponent<CoupleManager>().currentState = CoupleManager.CoupleState.couple;
            inheritor.Manager.GetComponent<CoupleManager>().UpdateCoupleInterface();

            DescentContainer.Instance.UpdateView();

            print(inheritor.Spouse.Manager);

            inheritor.Spouse.Manager.Face.InitWithValue();

            ResetWedding();
            ui.gameObject.SetActive(false);
        }
    }
}
