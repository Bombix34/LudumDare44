using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WeddingButton : MonoBehaviour
{
    [SerializeField]
    Button bouton;

    //public Inheritor CharacterToMarried { get; set; }

    void Start()
    {
    }

    public void OnClickWedding(CharacterManager character)
    {
        GameManager.Instance.GetComponent<WeddingManager>().LaunchWedding(character.CharacterInfos);
    }

}
