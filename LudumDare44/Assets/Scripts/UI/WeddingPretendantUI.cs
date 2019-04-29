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

    public Inheritor Current { get; set; }

    public void CreateView(Inheritor pretendant, Inheritor concerned)
    {
        bool isStrongSex = (concerned.isWomen == GameManager.Instance.IsWomenStrongSex);
        int monneyVal = pretendant.MonnaieValue+concerned.MonnaieValue;
        int influenceVal = pretendant.InfluenceValue+concerned.InfluenceValue;
        int affinityVal = Mathf.FloorToInt((pretendant.Attirance + concerned.Attirance)/2);

        this.Container.SetActive(true);
        this.Name.text = $"Name : {pretendant.Name}";
        this.FamilyName.text = $"FamilyName : {pretendant.FamilyName}";
        this.Age.text = $"Age : {pretendant.Age}";
        this.Trait.text = $"Trait : {pretendant.Trait}";

        if(isStrongSex)
        {
            influenceVal *= -1;
        }
        else
        {
            monneyVal *= -1;
        }
        this.price.text = $"Monney : {monneyVal}";
        this.influence.text = $"Influence : {influenceVal}";
        this.fertility.text = $"Affinity : {affinityVal}";

        portrait.SetuptFaceUI(pretendant);
        Current = pretendant;
        //Mathf.floor
    }
}
