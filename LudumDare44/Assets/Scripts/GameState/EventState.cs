using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventState : GameState
{
    public EventState(GameObject obj) : base(obj)
    {
        stateName = "EVENT_STATE";
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
