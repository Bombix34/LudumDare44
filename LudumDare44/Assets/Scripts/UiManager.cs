using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{

    public GameObject ressourcesPanel;
    public GameObject blazonPanel;
    public GameObject eventsHistoric;
    public GameObject eventsPanel;


    void Start()
    {
        ressourcesPanel.SetActive(true);
        blazonPanel.SetActive(true);
        eventsHistoric.SetActive(false);
        eventsPanel.SetActive(false);
    }

    void Update()
    {
        
    }
}
