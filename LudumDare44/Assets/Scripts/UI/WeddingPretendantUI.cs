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

    public Result result;

    public void CreateView(Inheritor pretendant, Inheritor concerned)
    {
        Current = pretendant;
        blazon.UpdateBlazon(pretendant);
        bool isStrongSex = (concerned.isWomen == GameManager.Instance.IsWomenStrongSex);
        result.monneyVal = pretendant.MonnaieValue+concerned.MonnaieValue;
        result.influenceVal = pretendant.InfluenceValue+concerned.InfluenceValue;
        result.affinityVal = Mathf.FloorToInt((pretendant.Attirance + concerned.Attirance)/2);

        this.Container.SetActive(true);
        this.Name.text = pretendant.Name;
        this.FamilyName.text = pretendant.FamilyName;
        this.Age.text = $"Age : {pretendant.Age}";
        if (pretendant.Trait != Inheritor.InheritorTrait.NONE)
            this.Trait.text = pretendant.Trait.ToString();
        else
            this.Trait.text = " ";


        //REGLE SEXE FORT___________________________
        if(isStrongSex)
        {
            result.influenceVal *= -1;
        }
        else
        {
            result.monneyVal *= -1;
        }

        //TRAIT______________________________________
        result = SetupFirstTrait(concerned,result);
        result = SetupFirstTrait(pretendant, result);
        result = SetupSecondTrait(concerned, result);
        result = SetupSecondTrait(pretendant, result);

        result = CheckImpossibleVal(result);

        this.price.text = result.monneyVal.ToString();
        this.influence.text = result.influenceVal.ToString();
        if (isStrongSex)
        {
            this.fertility.text = result.affinityVal.ToString();
            affinityLogo.SetActive(true);
        }
        else
        {
            this.fertility.text = " ";
            affinityLogo.SetActive(false);
        }

        portrait.SetuptFaceUI(pretendant);
        //Mathf.floor
    }

    public Result SetupFirstTrait(Inheritor concerned, Result toModif)
    {
        switch(concerned.Trait)
        {
            case Inheritor.InheritorTrait.MASTERMIND:
                toModif.influenceVal += 5;
                break;
            case Inheritor.InheritorTrait.DUMB:
                toModif.influenceVal -= 5;
                break;
            case Inheritor.InheritorTrait.COWARD:
                toModif.influenceVal -= 10;
                break;
            case Inheritor.InheritorTrait.UGLY:
                toModif.affinityVal -= 1;
                break;
            case Inheritor.InheritorTrait.BOLD:
                toModif.affinityVal += 1;
                break;
            case Inheritor.InheritorTrait.STINGY:
                toModif.monneyVal += 1000;
                break;
            case Inheritor.InheritorTrait.NOBLE:
                toModif.influenceVal += 15;
                toModif.monneyVal += 1500;
                toModif.affinityVal -= 2;
                break;
            case Inheritor.InheritorTrait.LIAR:
                toModif.monneyVal -= 1000;
                toModif.affinityVal += 2;
                break;
            case Inheritor.InheritorTrait.KLEPTOMANIAC:
                toModif.monneyVal -= 500;
                break;
            default:
                break;
        }
        return toModif;
    }

    public Result SetupSecondTrait(Inheritor concerned, Result toModif)
    {
        switch (concerned.Trait)
        {
            case Inheritor.InheritorTrait.HOMOSEXUAL:
                toModif.affinityVal = 1;
                break;
            default:
                break;
        }
        return toModif;
    }

    public Result CheckImpossibleVal(Result toCheck)
    {
        if (toCheck.affinityVal < 1)
            toCheck.affinityVal = 1;
        else if (toCheck.affinityVal > 4)
            toCheck.affinityVal = 4;

        return toCheck;
    }

    public struct Result
    {
        public int monneyVal;
        public int influenceVal;
        public int affinityVal;
    }
}
