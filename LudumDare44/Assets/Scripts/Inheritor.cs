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

   //public List<SpriteRenderer> RendererFaces { get; set; }

    public List<DuoGraphicElement> pairSpriteColor; //KEY = SPRITE - VALUE = COLOR
    public CharacterManager Manager { get; set; }
    

    public void Kill(){
        this.IsAlive = false;
    }

    public Inheritor()
    {
        IsAlive = true;
        Childrens = new List<Inheritor>();
        pairSpriteColor = new List<DuoGraphicElement>();
        Attirance = (int)Random.Range(1f, 4f);
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
