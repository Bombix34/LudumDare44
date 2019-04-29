using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoupleManager : MonoBehaviour
{
    [SerializeField]
    CharacterManager firstCharacter;

    [SerializeField]
    CharacterManager secondCharacter;

    [SerializeField]
    GameObject weddingButton;

    CoupleState currentState;

    void Start()
    {
        if (firstCharacter.CharacterInfos.Spouse != null)
            currentState = CoupleState.couple;
        else
        {
            currentState = CoupleState.single;
        }
        UpdateCoupleInterface();
    }

    public void UpdateCoupleInterface()
    {
        weddingButton.SetActive(false);
        switch (currentState)
        {
            case CoupleState.notBornYet:
                secondCharacter.Face.transform.gameObject.SetActive(false);
                break;
            case CoupleState.single:
                if (firstCharacter.CharacterInfos.IsAlive)
                {
                    secondCharacter.Face.transform.gameObject.SetActive(true);
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

    public enum CoupleState
    {
        notBornYet,
        single,
        couple
    }
}
