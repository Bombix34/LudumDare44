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
    public int goldCostByTurnByFamilyNumber;
    public int goldGainByTurnByInfluencePointPourcent;
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
            SoundManager.instance.PlaySound(1);
            RessourceUI.Instance.UpdateValue();
            if(goldCoins == 0){
                this.Ruined();
            }
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

    [SerializeField]
    Sprite crown;
    [SerializeField]
    Sprite heritierCrown;
    public EventScriptableObject EventFirstTurn;
    public EventScriptableObject EventSecondTurn;

    void Start()
    {
        //Init("De Moncul", true);
    }

    public void Init(string familyName, bool isWomenStrongSex){
        //debug
        IsWomenStrongSex = isWomenStrongSex;

        GoldCoins = 5000;
        InfluencePoints = 10;

        this.FamilyMaster = GetComponent<WeddingManager>().characterPool.GetCharacterWithoutFace(IsWomenStrongSex);
        this.FamilyMaster.FamilyName = familyName;
        this.FamilyMaster.Trait = Inheritor.InheritorTrait.NONE;
        DescentContainer.Instance.Init(this.FamilyMaster);
        InheritorUI.Instance.CreateView(this.FamilyMaster);
        this.FamilyMaster.Manager.GetComponent<CoupleManager>().SetCrown(crown);
        ChangeState(new WeddingState(this.gameObject));
    }

    void Update()
    {
        CurrentState?.Execute();
    }

    public void NextTurn()
    {
        var allToBorn = FamilyMaster.FindAllToBorn();
        foreach (var item in allToBorn)
        {
            item.NotBornYet = false;
        }

        GetComponent<WeddingManager>().UpdatePoolAge();

        var inheritors = new List<Inheritor>();
        FamilyMaster.FindAll(ref inheritors);

        foreach (var item in inheritors)
        {
            item.Age += 8;

            if (item.Age > 50)
            {
                if (item.Age > 70)
                    item.Kill();
                else
                {
                    int rand = (int)UnityEngine.Random.Range(0f, 99f);
                    if (rand <= 49)
                        item.Kill();
                }
            }
            if(item.Spouse != null){
                item.Spouse.Age += 8;
                if (item.Spouse.Age > 50)
                {
                    if (item.Spouse.Age > 70)
                        item.Spouse.Kill();
                    else
                    {
                        int rand = (int)UnityEngine.Random.Range(0f, 99f);
                        if (rand <= 49)
                            item.Spouse.Kill();
                    }
                }
            }

        }

        DescentContainer.Instance.UpdateView();
        this.GoldTurnCheck();
        if(!this.CanStillHaveChildrens()){
            this.GameOver("No more childrens");
        }
        
        ChangeState(new WeddingState(this.gameObject));
    }

    private void GoldTurnCheck(){
        var familySize = this.GetLivingInFamilyCharacters();
        this.GoldCoins -= familySize * goldCostByTurnByFamilyNumber;
        this.goldCoins += influencePoints * goldGainByTurnByInfluencePointPourcent;
    }

    private bool CanStillHaveChildrens(){
        var inheritors = new List<Inheritor>();
        this.FamilyMaster.FindAll(ref inheritors, false, false, false, this.IsWomenStrongSex);
        if(inheritors.Any(q => q.Spouse == null)){
            return true;
        }

        if(inheritors.Any(q => q.Spouse != null && q.Childrens.Any(c => c.NotBornYet))){
            return true;
        }

        return false;
    }

    public void CheckNewfamilyMaster()
    {
        UpdateHeritierCrown();
        if (this.FamilyMaster.IsAlive==false)
        {
            var inheritors = new List<Inheritor>();
            this.FamilyMaster.FindAll(ref inheritors, false, false, false, IsWomenStrongSex, null);
            if (inheritors.Count != 0)
            {
                this.FamilyMaster.Manager.GetComponent<CoupleManager>().SetCrown(null);
                this.FamilyMaster = inheritors[0];
                inheritors[0].Manager.GetComponent<CoupleManager>().SetCrown(crown);
                UpdateHeritierCrown();
            }
            else
                GameOver("All your family is dead");
        }
    }

    public void UpdateHeritierCrown()
    {
        var inheritors = new List<Inheritor>();
        this.FamilyMaster.FindAll(ref inheritors, false, false, false, IsWomenStrongSex, null);
        if (inheritors.Count > 0)
        {
            if (inheritors[0] == this.FamilyMaster)
            {
                if (inheritors.Count > 1)
                    inheritors[1].Manager.GetComponent<CoupleManager>().SetCrown(heritierCrown);
                return;
            }
            inheritors[0].Manager.GetComponent<CoupleManager>().SetCrown(heritierCrown);
        }
    }

    public void GameOver(string message)
    {
        GameOverUI.Instance.GameOver(message);
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
        if(this.Turn == 1){
            EventUI.Instance.CreateView(EventFirstTurn.ev);
            return;
        }   else if(this.Turn == 2){
            EventUI.Instance.CreateView(EventSecondTurn.ev);
            return;
        }
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

    public void UpdateAllCouple(){
        var inheritors = new List<Inheritor>();
        this.FamilyMaster.FindAll(ref inheritors, false, false, false, null, false);
        foreach (var item in inheritors)
        {
            item.Manager.GetComponent<CoupleManager>().UpdateCoupleInterface();
        }
    }

    public int GetLivingInFamilyCharacters()
    {
        int val = 0;
        var inheritors = new List<Inheritor>();
        this.FamilyMaster.FindAll(ref inheritors);
        val = inheritors.Count;
        foreach(var item in inheritors)
        {
            if (item.Spouse != null && item.Spouse.IsAlive)
                val++;
        }
        return val;
    }

    private void Ruined(){
        this.GameOver("Your family is ruined");
    }

}
