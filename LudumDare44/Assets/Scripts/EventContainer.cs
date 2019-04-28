using System;
using System.Collections;
using System.Collections.Generic;
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
}
[Serializable]
public class EventConditionContainer{

    public enum EventCondition
    {
        LESS_THAN_X_CHILD,
        MORE_THAN_X_CHILD,
        LESS_THAN_X_CHILD_STRONG_SEX,
        MORE_THAN_X_CHILD_STRONG_SEX,
        LESS_THAN_X_CHILD_LOW_SEX,
        MORE_THAN_X_CHILD_LOW_SEX,
        LESS_THAN_X_CHILD_WOMEN,
        MORE_THAN_X_CHILD_WOMAN,
        LESS_THAN_X_CHILD_MAN,
        MORE_THAN_X_CHILD_MAN,
        MORE_THAN_X_ALIVE,
    }
    public EventCondition Conditon;
    public int ConditionValue;

}
