using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WeddingButton : MonoBehaviour
{
    [SerializeField]
    Button bouton;


    void Start()
    {
        bouton.onClick.AddListener(OnClickWedding);
    }

    public void OnClickWedding()
    {
        Debug.Log("clickeu");
    }

}
