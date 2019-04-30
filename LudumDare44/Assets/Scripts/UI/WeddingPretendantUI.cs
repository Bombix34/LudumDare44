using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeddingPretendantUI : MonoBehaviour
{   
    public GameObject Container;
    public Text Name;
    public Text FamilyName;
    public Text Age;
    public Text Trait;

    public Text price;
    public Text influence;
    public Text fertility;

    public PortraitUI portrait;

    public GameObject affinityLogo;
    public BlazonPanel blazon;

    public Inheritor Current { get; set; }

    public void CreateView(Inheritor pretendant, Inheritor concerned)
    {
        blazon.UpdateBlazon(pretendant);
        bool isStrongSex = (concerned.isWomen == GameManager.Instance.IsWomenStrongSex);
        int monneyVal = pretendant.MonnaieValue+concerned.MonnaieValue;
        int influenceVal = pretendant.InfluenceValue+concerned.InfluenceValue;
        int affinityVal = Mathf.FloorToInt((pretendant.Attirance + concerned.Attirance)/2);

        this.Container.SetActive(true);
        this.Name.text = pretendant.Name;
        this.FamilyName.text = pretendant.FamilyName;
        this.Age.text = $"Age : {pretendant.Age}";
        if (pretendant.Trait != Inheritor.InheritorTrait.NONE)
            this.Trait.text = pretendant.Trait.ToString();
        else
            this.Trait.text = " ";

        if(isStrongSex)
        {
            influenceVal *= -1;
        }
        else
        {
            monneyVal *= -1;
        }
        this.price.text = monneyVal.ToString();
        this.influence.text = influenceVal.ToString();
        if (isStrongSex)
        {
            this.fertility.text = affinityVal.ToString();
            affinityLogo.SetActive(true);
        }
        else
        {
            this.fertility.text = " ";
            affinityLogo.SetActive(false);
        }

        portrait.SetuptFaceUI(pretendant);
        Current = pretendant;
        //Mathf.floor
    }
}
