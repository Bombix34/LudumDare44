using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inheritor
{
    public string Name { get; set; }
    public bool isWomen { get; set; }
    public bool IsAlive { get; set; }
    public Inheritor Spouse { get; set; }

    public Inheritor Parent { get; set; }
    public List<Inheritor> Childrens { get; set; }

   //public List<SpriteRenderer> RendererFaces { get; set; }

    public List<DuoGraphicElement> pairSpriteColor; //KEY = SPRITE - VALUE = COLOR
    public CharacterManager Manager { get; set; }

    public Inheritor()
    {
        IsAlive = true;
        Childrens = new List<Inheritor>();
        pairSpriteColor = new List<DuoGraphicElement>();
    }

    public List<Inheritor> FindAllLegitimateChild(ref List<Inheritor> inheritors, bool fromChildren = false, bool fromBrother = false){
        if(this.IsAlive){
            inheritors.Add(this);
        }
        if(!fromChildren && this.Childrens.Count > 0){
            this.Childrens.First().FindAllLegitimateChild(ref inheritors);
        }

        if(!fromBrother){
            if(this.Parent != null){
                if(this.Parent.Childrens.Count > 1){
                    foreach (var brother in this.Parent.Childrens)
                    {
                        if(brother == this){
                            continue;
                        }
                        this.Childrens.First().FindAllLegitimateChild(ref inheritors);
                    }
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
