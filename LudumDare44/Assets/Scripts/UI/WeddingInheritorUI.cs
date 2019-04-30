using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeddingInheritorUI : MonoBehaviour
{
    public GameObject Container;
    public Text Name;
    public Text FamilyName;
    public Text Age;
    public Text Trait;

    public void CreateView(Inheritor inheritor)
    {
        this.Container.SetActive(true);
        this.Name.text = inheritor.Name;
        this.FamilyName.text = inheritor.FamilyName;
        this.Age.text = $"Age : {inheritor.Age}";
        if(inheritor.Trait!=Inheritor.InheritorTrait.NONE)
            this.Trait.text = inheritor.Trait.ToString();
        else
            this.Trait.text = " ";
    }
}
