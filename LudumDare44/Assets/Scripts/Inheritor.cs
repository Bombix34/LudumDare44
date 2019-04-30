using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inheritor
{
    public enum InheritorTrait
    {
        NONE,
        WARLIKE,
        MASTERMIND,
        DUMB,
        ROMANTIC,
        HOMOSEXUAL,
        COWARD,
        UGLY,
        BOLD,
        STINGY,
        CONQUEROR,
        NOBLE,
        JUST,
        LIAR,
        KLEPTOMANIAC,
        PIOUS
    }
    public string Name { get; set; }
    public string FamilyName { get; set; }
    public int Age { get; set; }
    public bool isWomen { get; set; }
    public bool IsAlive { get; set; }
    public bool NotBornYet { get; set; }
    public int Attirance { get; set; }
    public Inheritor Spouse { get; set; }
    public InheritorTrait Trait { get; set; }
    public Inheritor Parent { get; set; }
    public List<Inheritor> Childrens { get; set; }

    public int MonnaieValue { get; set; }
    public int InfluenceValue { get; set; }

   //public List<SpriteRenderer> RendererFaces { get; set; }

    public List<DuoGraphicElement> pairSpriteColor; //KEY = SPRITE - VALUE = COLOR
    public CharacterManager Manager { get; set; }
    

    public void Kill(){
        this.IsAlive = false;
        this.Manager.CoupleManager.UpdateCoupleInterface();
        var childsNotBorn = this.Childrens.Where(q => q.NotBornYet).ToList();
        foreach (var item in childsNotBorn)
        {
            DescentContainer.Instance.RemoveInheritor(item);
            this.Childrens.Remove(item);
        }
    }

    public Inheritor()
    {
        IsAlive = true;
        Childrens = new List<Inheritor>();
        pairSpriteColor = new List<DuoGraphicElement>();
        Attirance = (int)Random.Range(1f, 4f);
        MonnaieValue = (int)Random.Range(100f, 1000F);
        InfluenceValue = (int)Random.Range(1f, 5f);
    }

    public void UpdateBlazon(){
        var BlazonManager = new BlazonManager();
        BlazonManager.Random(this.FamilyName);
    }

    public List<Inheritor> FindAll(ref List<Inheritor> inheritors, bool fromChildren = false, bool fromBrother = false
                                    , bool fromParent = false, bool? isWomen = null, bool? isMarried = null
                                    , InheritorTrait? trait = null){
        if(this.IsAlive && !this.NotBornYet 
            && (isWomen == null || this.isWomen == isWomen)
            && (isMarried == null || ((this.Spouse != null) == isMarried))
            && (trait == null || this.Trait == trait)){
            inheritors.Add(this);
        }
        if(!fromChildren && this.Childrens.Count > 0){
            this.Childrens.First().FindAll(ref inheritors, false, false, true, isWomen, isMarried, trait);
        }

        if(!fromBrother){
            if(this.Parent != null){
                if(this.Parent.Childrens.Count > 1){
                    foreach (var brother in this.Parent.Childrens)
                    {
                        if(brother == this){
                            continue;
                        }
                        brother.FindAll(ref inheritors, false, true, false, isWomen, isMarried, trait);
                    }
                }
                if(!fromParent){
                    this.Parent.FindAll(ref inheritors, true, false, false, isWomen, isMarried, trait);
                }
            }

        }
        return inheritors;
    }

    public List<Inheritor> FindAll(List<Inheritor> inheritors, bool fromChildren = false, bool fromBrother = false
                                    , bool fromParent = false, bool? isWomen = null, bool? isMarried = null
                                    , InheritorTrait? trait = null){
        if(this.IsAlive && !this.NotBornYet 
            && (isWomen == null || this.isWomen == isWomen)
            && (isMarried == null || ((this.Spouse != null) == isMarried))
            && (trait == null || this.Trait == trait)){
            inheritors.Add(this);
        }
        if(!fromChildren && this.Childrens.Count > 0){
            this.Childrens.First().FindAll(inheritors, false, false, true, isWomen, isMarried, trait);
        }

        if(!fromBrother){
            if(this.Parent != null){
                if(this.Parent.Childrens.Count > 1){
                    foreach (var brother in this.Parent.Childrens)
                    {
                        if(brother == this){
                            continue;
                        }
                        brother.FindAll(inheritors, false, true, false, isWomen, isMarried, trait);
                    }
                }
                if(!fromParent){
                    this.Parent.FindAll(inheritors, true, false, false, isWomen, isMarried, trait);
                }
            }

        }
        return inheritors;
    }

    public List<Inheritor> FindAllToBorn()
    {
        var result = new List<Inheritor>();
        var inheritors = new List<Inheritor>();
        this.FindAll(ref inheritors);
        foreach (var item in inheritors)
        {
            var notBorn = item.Childrens.Where(q => q.NotBornYet).ToList();
            if(notBorn.Count > 0)
            {
                result.Add(notBorn.First());
            }
        }
        return result;
    }


}

public class DuoGraphicElement
{
    public Sprite Sprite { get; set; }
    public Color ElementColor { get; set; }

    public DuoGraphicElement(Sprite newSprite, Color curcolor)
    {
        Sprite = newSprite;
        ElementColor = curcolor;
    }
}
