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
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
