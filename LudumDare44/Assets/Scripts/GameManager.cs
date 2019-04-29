using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Start()
    {
        //debug
        ManIsStrongSex = true;
        ChangeState(new WeddingState(this.gameObject));
    }

    void Update()
    {
        CurrentState.Execute();
    }

    public void ChangeState(State newState)
    {
        if (CurrentState != null)
            CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }


}
