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
    private int goldCoins;
    public int GoldCoins 
    { 
        get { 
            return goldCoins; 
            } 
        set {
            if (value < 0)
            {
                goldCoins = 0;
            }
            else
            {
                goldCoins = value;
            }
            RessourceUI.Instance.UpdateValue();
        } 
     }
    private int influencePoints;
    public int InfluencePoints {
        get { return influencePoints; } 
        set {
            if (value < 0)
                influencePoints = 0;
            else if (InfluencePoints > 100)
            {
                influencePoints = 100;
            }
            else
                influencePoints = value;
            RessourceUI.Instance.UpdateValue();
        } 
    }

    public Inheritor FamilyMaster { get; set; }
    public State CurrentState { get; set; }
    public bool IsWomenStrongSex { get; set; }
    public EventsScriptableObject EventsScriptableObject;


    void Start()
    {
        ChangeState(new WeddingState(this.gameObject));
        //debug
        IsWomenStrongSex = false;

        GoldCoins = 5000;
        InfluencePoints = 10;
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

    public void NextTurn()
    {
        var allToBorn = FamilyMaster.FindAllToBorn();
        foreach (var item in allToBorn)
        {
            item.NotBornYet = false;
        }

        var inheritors = new List<Inheritor>();
        FamilyMaster.FindAll(ref inheritors);

        foreach (var item in inheritors)
        {
            item.Age += 8;
            item.Spouse.Age += 8;

            if (item.Age > 50)
            {
                item.Kill();
            }
            if (item.Spouse.Age > 50)
            {
                item.Spouse.Kill();
            }

        }
        ChangeState(new WeddingState(this.gameObject));
    }


    public void FinishWedding()
    {
        ChangeState(new EventState(this.gameObject));
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
