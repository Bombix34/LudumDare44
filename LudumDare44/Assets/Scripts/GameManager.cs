using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class GameManager : Singleton<GameManager>
{
    public BlazonDatabase BlazonDatabase;
    enum TurnState
    {
        WEDDING,
        EVENT,
    }
    public int Turn { get; set; }
    public int GoldCoins { get; set; }
    public int InfluencePoints { get; set; }
    public Inheritor FamilyMaster { get; set; }
    public State CurrentState { get; set; }
    public bool IsWomenStrongSex { get; set; }
    public EventsScriptableObject EventsScriptableObject;

    void Start()
    {
        //debug
        ChangeState(new WeddingState(this.gameObject));
        IsWomenStrongSex = true;
    }

    void Update()
    {
        CurrentState.Execute();
        
        if(Input.GetKeyDown("t"))
        {
            this.ChooseEvent();
        }
        if(Input.GetKeyDown("y"))
        {
            InheritorUI.Instance.CreateView(this.FamilyMaster);
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
        EventUI.Instance.CreateView(choosenOne.ev);
    }

    private List<EventScriptableObject> GetListAvailableEvents(){
        return EventsScriptableObject.events.Where(q => q.ev.AreConditionValid()).ToList();
    }

}
