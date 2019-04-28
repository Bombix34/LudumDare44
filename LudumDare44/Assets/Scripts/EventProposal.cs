using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EventProposal
{
    public enum ProposalEffect
    {
        NONE,
        COST_OR_GAIN_INFLUENCE_POINTS,
        COST_OR_GAIN_CURRENCY,
        INHERITOR_DEATH,
    }
    [TextArea(3,10)]
    public string Choice;
    [TextArea(3,10)]
    public string Response;
    public ProposalEffect Effect;
    public int EffectValue;

    public void DoEffect(EffectParams effectParams){
        switch (this.Effect)
        {
            case(ProposalEffect.NONE):
                break;
            case(ProposalEffect.COST_OR_GAIN_INFLUENCE_POINTS):
                break;
            case(ProposalEffect.COST_OR_GAIN_CURRENCY):
                break;
            case(ProposalEffect.INHERITOR_DEATH):
                //effectParams.Inheritor;
                break;
            
            default:
                break;
        }
    }
}

public class EffectParams{
    public Inheritor Inheritor { get; set; }
}
