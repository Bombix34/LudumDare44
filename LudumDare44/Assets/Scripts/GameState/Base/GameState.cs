using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : State
{
    protected GameManager manager;

    public GameState(GameObject obj) : base(obj)
    {
        stateName = "GAME_STATE";
        this.curObject = obj;
        manager = GameManager.Instance;
    }

    public override void Enter()
    {
    }

    public override void Execute()
    {
    }

    public override void Exit()
    {
    }
}
