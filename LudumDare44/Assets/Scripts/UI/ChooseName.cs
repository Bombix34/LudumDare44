using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseName : MonoBehaviour
{
    public InputField input;
    public GameObject MainUI;


    public void ChooseStrongSex(bool isWomenStrongSex){
        MainUI.SetActive(true);
        GameManager.Instance.Init(input.text, isWomenStrongSex);
        GameManager.Instance.gameObject.GetComponent<WeddingManager>().enabled = true;
        gameObject.SetActive(false);
    }
}
