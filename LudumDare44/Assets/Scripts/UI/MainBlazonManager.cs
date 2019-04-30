using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainBlazonManager : Singleton<MainBlazonManager>
{

    public Text familyName;
    public BlazonPanel blazon;

    public void InitMainBlazon(Inheritor king)
    {
        familyName.text = king.FamilyName;
        blazon.UpdateBlazon(king);
    }
}
