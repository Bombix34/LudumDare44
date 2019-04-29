using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

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
    public bool ManIsStrongSex { get; set; }
    public State CurrentState { get; set; }
    public bool IsWomenStrongSex { get; set; }
    public EventsScriptableObject EventsScriptableObject;

    void Start()
    {
        //debug
        ManIsStrongSex = true;
        ChangeState(new WeddingState(this.gameObject));
        IsWomenStrongSex = false;
    }

    void Update()
    {
        CurrentState.Execute();
        
        if(Input.GetKeyDown("t"))
        {
            this.ChooseEvent();
        }
    }

    public void ChangeState(State newState)
    {
        if (CurrentState != null)
            CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }
    public void ChooseEvent(){
        var events = this.GetListAvailableEvents();
        if(events.Count == 0){
            return;
        }
        var choosenOne = events.OrderBy(x => Guid.NewGuid()).First();
        EventUI.Instance.CreateView(choosenOne);
    }

    private List<EventContainer> GetListAvailableEvents(){
        return EventsScriptableObject.events.Where(q => q.AreConditionValid()).ToList();
    }

}
