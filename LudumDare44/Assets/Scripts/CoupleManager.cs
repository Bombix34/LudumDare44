using System.Collections;
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

    public CoupleState currentState;

    private void Awake()
    {

    }

    void Start()
    {
        infoButon.onClick.AddListener(OnClickInfoFirstCharacter);
        spouseInfoButon.onClick.AddListener(OnClickInfoSecondCharacter);

        UpdateCoupleInterface();
    }

   public void UpdateCoupleInterface()
    {
        if(firstCharacter.CharacterInfos.NotBornYet){
            currentState = CoupleState.notBornYet;
        }   else
        {
            if (firstCharacter.CharacterInfos.Spouse != null)
                currentState = CoupleState.couple;
            else
            {
                currentState = CoupleState.single;
            }
        }

        weddingButton.SetActive(false);
        weddingButton.GetComponentInChildren<Button>().interactable = false;
        switch (currentState)
        {
            case CoupleState.notBornYet:
                infoButon.transform.parent.gameObject.SetActive(false);
                spouseInfoButon.transform.parent.gameObject.SetActive(false);
                firstCharacter.Face.transform.gameObject.SetActive(false);
                secondCharacter.Face.transform.parent.gameObject.SetActive(false);
                break;
            case CoupleState.single:
            
                firstCharacter.Face.transform.gameObject.SetActive(true);
                secondCharacter.Face.transform.parent.gameObject.SetActive(true);
                spouseInfoButon.transform.parent.gameObject.SetActive(false);
                print(firstCharacter.CharacterInfos.IsAlive);
                if (firstCharacter.CharacterInfos.IsAlive)
                {
                    secondCharacter.Face.transform.gameObject.SetActive(true);
                    weddingButton.GetComponentInChildren<Button>().interactable = true;
                    if (GameManager.Instance.CurrentState.stateName == "WEDDING_STATE")
                    {
                        weddingButton.SetActive(true);
                    }
                }else//IF DEAD
                {
                    firstCharacter.Face.DieFeedback();
                    secondCharacter.Face.transform.parent.gameObject.SetActive(false);
                }
                break;
            case CoupleState.couple:
            
                firstCharacter.Face.transform.gameObject.SetActive(true);
                secondCharacter.Face.transform.parent.gameObject.SetActive(true);
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

    public void SetupSecondCharacter(Inheritor character)
    {
        secondCharacter.CharacterInfos = character;
        character.Manager = secondCharacter;
    }

    public void OnClickInfoFirstCharacter()
    {
        SoundManager.instance.PlaySound(1);
        InheritorUI.Instance.CreateView(this.firstCharacter.CharacterInfos);
    }

    public void OnClickInfoSecondCharacter()
    {
        SoundManager.instance.PlaySound(1);
        InheritorUI.Instance.CreateView(this.secondCharacter.CharacterInfos);
    }

    public enum CoupleState
    {
        notBornYet,
        single,
        couple
    }
}
