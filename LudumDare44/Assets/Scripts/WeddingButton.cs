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
        bouton.onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        Debug.Log("clickeu");
    }
}
