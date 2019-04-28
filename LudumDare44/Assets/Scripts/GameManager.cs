using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : ObjectManagerSingleton<GameManager>
{
    enum TurnState
    {
        WEDDING,
        EVENT,
    }
    public int Turn { get; set; }
    public int GoldCoins { get; set; }
    public int InfluencePoints { get; set; }
    public bool ManIsStrongSex { get; set; }

    void Start()
    {
        //debug
        ManIsStrongSex = true;
    }

    void Update()
    {
        
    }



}
