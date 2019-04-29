using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
[Serializable]
public class EventContainer
{
    public List<EventConditionContainer> Conditions;
    [TextArea(3,10)]
    public string Message;
    public EventProposal ProposalOne;
    public EventProposal ProposalTwo;
    public EventProposal ProposalSpecial;
    public Inheritor Inheritor { get; set; }
    

    public bool AreConditionValid(){
        if(Conditions.Count == 0){
            return true;
        }
        List<Inheritor> inheritors = null;
        foreach (var condition in Conditions)
        {
            bool? specialConditionSuccess = null;
            var newInheritors = new List<Inheritor>();
            switch (condition.Condition)
            {
                case(EventConditionContainer.EventCondition.HAVE_TRAIT):
                    GameManager.Instance.FamilyMaster.FindAll(ref newInheritors, false, false, false, condition.IsWomen(), null, condition.ConditionTrait);
                    break;
                case(EventConditionContainer.EventCondition.FAMILY_MORE_THAN):
                    GameManager.Instance.FamilyMaster.FindAll(ref newInheritors, false, false, false, condition.IsWomen());
                    if(newInheritors.Count() < condition.ConditionValue){
                        newInheritors = new List<Inheritor>();
                    }
                    break;
                case(EventConditionContainer.EventCondition.CHILD_MORE_THAN):
                    GameManager.Instance.FamilyMaster.FindAll(ref newInheritors, false, true, true, condition.IsWomen());
                    newInheritors.Remove(GameManager.Instance.FamilyMaster);
                    if(newInheritors.Count() < condition.ConditionValue){
                        newInheritors = new List<Inheritor>();
                    }
                    break;
                case(EventConditionContainer.EventCondition.HAVE_MORE_GOLD_THAN):
                    specialConditionSuccess = GameManager.Instance.GoldCoins >= condition.ConditionValue;
                    break;
                case(EventConditionContainer.EventCondition.HAVE_MORE_INFLUENCE_THAN):
                    specialConditionSuccess = GameManager.Instance.InfluencePoints >= condition.ConditionValue;
                    break;
                case(EventConditionContainer.EventCondition.CHILD_AT_POSITION):
                    var isWomen = condition.IsWomen();
                    var childrens = GameManager.Instance.FamilyMaster.Childrens.Where(q => q.IsAlive);
                    if(isWomen != null){
                        childrens.Where(q => q.isWomen == isWomen);
                    }
                    if(childrens.Count() >= condition.ConditionValue){
                        newInheritors.Add(childrens.ElementAt(condition.ConditionValue - 1));
                    }

                    break;
                case(EventConditionContainer.EventCondition.IS_MARRIED):
                    GameManager.Instance.FamilyMaster.FindAll(ref newInheritors, false, false, false, condition.IsWomen(), condition.ConditionBoolValue);
                    newInheritors.Remove(GameManager.Instance.FamilyMaster);
                    if(newInheritors.Count() < condition.ConditionValue){
                        newInheritors = new List<Inheritor>();
                    }
                    break;                
                default:
                    break;
            }

            if(specialConditionSuccess.HasValue){
                if(!specialConditionSuccess.Value){
                    inheritors = new List<Inheritor>();
                }
            }   else
            {
                if (inheritors == null)
                {
                    inheritors = newInheritors;
                }
                else
                {
                    inheritors = inheritors.Intersect(newInheritors).ToList();
                }
            }
        }

        if(inheritors == null){
            return true;
        } 
        if(inheritors.Count > 0){
            this.Inheritor = inheritors.OrderBy(x => Guid.NewGuid()).First();
            return true;
        }   else
        {
            this.Inheritor = null;
            return false;
        }
    }

    public EffectParams GetEffectParams(){
        return new EffectParams(){
            Inheritor = this.Inheritor
        };
    }

    public string GetMessage(){
        return FormatText(this.Message);
    }

    public string FormatText(string text){
        return text.Replace("$charactername", $"{this.Inheritor?.Name} {this.Inheritor?.FamilyName}");
    }

    public void ChooseProposalOne(){
        this.ProposalOne.DoEffects(new EffectParams(){
            Inheritor = this.Inheritor
        });
    }

    public void ChooseProposalTwo(){
        this.ProposalTwo.DoEffects(new EffectParams(){
            Inheritor = this.Inheritor
        });
    }

    public void ChooseProposalSpecial(){
        this.ProposalSpecial.DoEffects(new EffectParams(){
            Inheritor = this.Inheritor
        });
    }
}
[Serializable]
public class EventConditionContainer{
    public enum InheritorCondition
    {
        ANY,
        WOMEN,
        MEN,
        STRONG_SEXE,
        LOW_SEX
    }
    public enum EventCondition
    {
        HAVE_TRAIT,
        FAMILY_MORE_THAN,
        CHILD_MORE_THAN,
        HAVE_MORE_GOLD_THAN,
        HAVE_MORE_INFLUENCE_THAN,
        CHILD_AT_POSITION,
        IS_MARRIED

    }
    public EventCondition Condition;
    public int ConditionValue;
    public bool ConditionBoolValue;
    public Inheritor.InheritorTrait ConditionTrait;
    public InheritorCondition inheritorCondition;
    public bool? IsWomen(){
        bool? result;
        switch (this.inheritorCondition)
        {
            case(InheritorCondition.ANY):
                result = null;
                break;
            case(InheritorCondition.WOMEN):
                result = true;
                break;
            case(InheritorCondition.MEN):
                result = false;
                break;
            case(InheritorCondition.STRONG_SEXE):
                result = GameManager.Instance.IsWomenStrongSex;
                break;
            case(InheritorCondition.LOW_SEX):
                result = !GameManager.Instance.IsWomenStrongSex;
                break;
            default:
                result = null;
                break;
        }
        return result;
    }
}
