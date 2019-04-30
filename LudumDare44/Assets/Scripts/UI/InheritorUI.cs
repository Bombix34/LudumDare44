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

    public BlazonPanel blazon;
    public PortraitUI portrait;

    public void CreateView(Inheritor inheritor)
    {
        if (blazon != null)
            blazon.UpdateBlazon(inheritor);
        if (portrait != null)
            portrait.SetuptFaceUI(inheritor);
        this.Container.SetActive(true);
        this.Name.text = inheritor.Name;
        this.FamilyName.text = inheritor.FamilyName;
        if(inheritor.IsAlive)
            this.Age.text = $"Age : {inheritor.Age}";
        else if(inheritor.IsGone)
            this.Age.text = "Age : GONE FOREVER";
        else
            this.Age.text = "Age : DEAD";
        if (inheritor.Trait != Inheritor.InheritorTrait.NONE)
            this.Trait.text = inheritor.Trait.ToString();
        else
            this.Trait.text = " ";
    }

    public void Close(){
        this.Container.SetActive(false);
    }
}
