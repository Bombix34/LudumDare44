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

    public void CreateView(Inheritor pretendant, int inheritorFertility)
    {
        this.Container.SetActive(true);
        this.Name.text = $"Name : {pretendant.Name}";
        this.FamilyName.text = $"FamilyName : {pretendant.FamilyName}";
        this.Age.text = $"Age : {pretendant.Age}";
        this.Trait.text = $"Trait : {pretendant.Trait}";

        this.price.text = $"Monney : {10}";
        this.influence.text = $"Influence : {10}";
        this.fertility.text = $"Affinity : {inheritorFertility}";

        portrait.SetuptFaceUI(pretendant);

        //Mathf.floor
    }
}
