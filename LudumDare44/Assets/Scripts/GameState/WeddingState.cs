﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeddingState : GameState
{
    public WeddingState(GameObject obj) : base(obj)
    {
        stateName = "WEDDING_STATE";
        this.curObject = obj;
        manager = GameManager.Instance;
    }

    public override void Enter()
    {
        manager.Turn++;
    }

    public override void Execute()
    {
    }

    public override void Exit()
    {
    }
}
