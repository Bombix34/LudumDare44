using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RessourceUI : Singleton<RessourceUI>
{
    public Text monneyRessource;
    public Text affinityRessource;
    public Text charactersRessource;

    public void UpdateValue()
    {
        monneyRessource.text= GameManager.Instance.GoldCoins.ToString();
        affinityRessource.text = GameManager.Instance.InfluencePoints.ToString()+" %";
    }

    public void UpdateCharacters()
    {
        charactersRessource.text = GameManager.Instance.GetLivingInFamilyCharacters().ToString();
    }
}
