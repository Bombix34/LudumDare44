using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        INHERITOR_RANDOM_DEATH,
        KING_DEATH,
        NEXT_KING_DEATH
    }
    public ProposalEffect Effect;
    public int EffectValue;

    public void DoEffect(EffectParams effectParams){
        
        var inheritors = new List<Inheritor>();
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
            case(ProposalEffect.INHERITOR_RANDOM_DEATH):
                GameManager.Instance.FamilyMaster.FindAll(ref inheritors);
                inheritors = inheritors.OrderBy(x => Guid.NewGuid()).ToList();
                for (int i = 0; i < EffectValue && i < inheritors.Count; i++)
                {
                    inheritors[i].Kill();   
                }
                break;
            case(ProposalEffect.KING_DEATH):
                GameManager.Instance.FamilyMaster.Kill();
                break;
            case(ProposalEffect.NEXT_KING_DEATH):
                GameManager.Instance.FamilyMaster.FindAll(ref inheritors);
                if(inheritors.Count > EffectValue - 1){
                    inheritors.ElementAt(EffectValue - 1).Kill();
                }
                break;
            default:
                break;
        }
    }
}

public class EffectParams{
    public Inheritor Inheritor { get; set; }
}
