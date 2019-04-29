using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : Singleton<UiManager>
{

    public GameObject weddingPanel;


    void Start()
    {
        weddingPanel.SetActive(false);
    }

    void Update()
    {
        
    }

    public void ShowWeddingPanel(bool isAlive)
    {
        weddingPanel.SetActive(isAlive);
    }
}
