using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseName : MonoBehaviour
{
    public InputField input;
    public GameObject MainUI;

    public GameObject startBouton;

    public Button patriarcBouton;
    public Button matriarcBouton;

    Color baseColor;

    bool isWomenStrongSex=false;
    bool initSex = false;

    private void Start()
    {
        startBouton.SetActive(false);
        baseColor = patriarcBouton.GetComponent<Image>().color;
    }

    public void Update()
    {
        if (input.text == "")
            startBouton.SetActive(false);
        else if(initSex)
            startBouton.SetActive(true);
    }

    public void ChooseStrongSex(bool isWomenStrongSex)
    {
        this.isWomenStrongSex = isWomenStrongSex;
        if (isWomenStrongSex)
        {
            matriarcBouton.GetComponent<Image>().color = Color.green;
            patriarcBouton.GetComponent<Image>().color = baseColor;
        }
        else
        {
            matriarcBouton.GetComponent<Image>().color = baseColor;
            patriarcBouton.GetComponent<Image>().color = Color.green;
        }
        initSex = true;
    }

    public void StartGame()
    {
        MainUI.SetActive(true);
        GameManager.Instance.Init(input.text, isWomenStrongSex);
        GameManager.Instance.gameObject.GetComponent<WeddingManager>().enabled = true;
        gameObject.SetActive(false);
    }
}
