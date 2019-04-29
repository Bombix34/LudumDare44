using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InheritorUI : Singleton<InheritorUI>
{
    public GameObject Container;
    public Text Name;
    public Text FamilyName;
    public Text Age;
    public Text Trait;

    public void CreateView(Inheritor inheritor)
    {
        print(inheritor);
        this.Container.SetActive(true);
        this.Name.text = $"Name : {inheritor.Name}";
        this.FamilyName.text = $"FamilyName : {inheritor.FamilyName}";
        this.Age.text = $"Age : {inheritor.Age}";
        this.Trait.text = $"Trait : {inheritor.Trait}";
    }

    public void Close(){
        this.Container.SetActive(false);
    }
}
