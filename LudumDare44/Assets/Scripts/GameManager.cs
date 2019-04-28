using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : Singleton<GameManager>
{
    enum TurnState
    {
        WEDDING,
        EVENT,
    }
    public int Turn { get; set; }
    public int GoldCoins { get; set; }
    public int InfluencePoints { get; set; }
    public Inheritor FamilyMaster { get; set; }
    public bool IsWomenStrongSex { get; set; }
    public EventsScriptableObject EventsScriptableObject;

    void Start()
    {
        //debug
        IsWomenStrongSex = false;
    }

    void Update()
    {
        
    }

    private List<EventContainer> GetListAvailableEvents(){
        return EventsScriptableObject.events.Where(q => q.AreConditionValid()).ToList();
    }

}
