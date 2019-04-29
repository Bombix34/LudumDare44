using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EventProposal
{
    [TextArea(3,10)]
    public string Choice;
    [TextArea(3,10)]
    public string Response;
    public List<EventEffectContainer> effects;

    public void DoEffects(EffectParams effectParams){
        foreach (var effect in effects)
        {
            effect.DoEffect(effectParams);
        }
    }
}

[Serializable]
public class EventEffectContainer{
    
    public enum ProposalEffect
    {
        COST_OR_GAIN_INFLUENCE_POINTS,
        COST_OR_GAIN_GOLD,
        INHERITOR_DEATH,
    }
    public ProposalEffect Effect;
    public int EffectValue;

    public void DoEffect(EffectParams effectParams){
        switch (this.Effect)
        {
            case(ProposalEffect.COST_OR_GAIN_INFLUENCE_POINTS):
                GameManager.Instance.InfluencePoints += EffectValue;
                break;
            case(ProposalEffect.COST_OR_GAIN_GOLD):
                GameManager.Instance.GoldCoins += EffectValue;
                break;
            case(ProposalEffect.INHERITOR_DEATH):
                effectParams.Inheritor?.Kill();
                break;
            
            default:
                break;
        }
    }
}

public class EffectParams{
    public Inheritor Inheritor { get; set; }
}
