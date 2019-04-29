﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoupleManager : MonoBehaviour
{
    [SerializeField]
    CharacterManager firstCharacter;

    [SerializeField]
    CharacterManager secondCharacter;

    [SerializeField]
    GameObject weddingButton;

    [SerializeField]
    Button infoButon;

    [SerializeField]
    Button spouseInfoButon;

    CoupleState currentState;

    void Start()
    {
        //debug
        if (firstCharacter.CharacterInfos.Spouse != null)
            currentState = CoupleState.couple;
        else
        {
            currentState = CoupleState.single;
        }

        infoButon.onClick.AddListener(OnClickInfoFirstCharacter);
        spouseInfoButon.onClick.AddListener(OnClickInfoSecondCharacter);

        UpdateCoupleInterface();
    }

   public void UpdateCoupleInterface()
    {

        weddingButton.SetActive(false);
        weddingButton.GetComponentInChildren<Button>().interactable = false;
        switch (currentState)
        {
            case CoupleState.notBornYet:
                infoButon.transform.parent.gameObject.SetActive(false);
                spouseInfoButon.transform.parent.gameObject.SetActive(false);
                secondCharacter.Face.transform.gameObject.SetActive(false);
                break;
            case CoupleState.single:
                spouseInfoButon.transform.parent.gameObject.SetActive(false);
                if (firstCharacter.CharacterInfos.IsAlive)
                {
                    secondCharacter.Face.transform.gameObject.SetActive(true);
                    weddingButton.GetComponentInChildren<Button>().interactable = true;
                    if (GameManager.Instance.CurrentState.stateName == "WEDDING_STATE")
                    {
                        weddingButton.SetActive(true);
                    }
                }else
                {
                    secondCharacter.Face.transform.gameObject.SetActive(false);
                    firstCharacter.Face.DieFeedback();
                }
                break;
            case CoupleState.couple:
                infoButon.transform.parent.gameObject.SetActive(true);
                spouseInfoButon.transform.parent.gameObject.SetActive(true);
                if (firstCharacter.CharacterInfos.IsAlive)
                {
                }else
                {
                    firstCharacter.Face.DieFeedback();
                }
                if (secondCharacter.CharacterInfos.IsAlive)
                {
                }
                else
                {
                    secondCharacter.Face.DieFeedback();
                }
                break;
        }
    }

    public void OnClickInfoFirstCharacter()
    {
        InheritorUI.Instance.CreateView(this.firstCharacter.CharacterInfos);
    }

    public void OnClickInfoSecondCharacter()
    {
        InheritorUI.Instance.CreateView(this.secondCharacter.CharacterInfos);
    }

    public enum CoupleState
    {
        notBornYet,
        single,
        couple
    }
}
