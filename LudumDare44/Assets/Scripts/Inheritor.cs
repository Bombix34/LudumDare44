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

    public List<SpriteRenderer> RendererFaces { get; set; }

    public Inheritor()
    {
        Childrens = new List<Inheritor>();
        RendererFaces = new List<SpriteRenderer>();
    }

    public List<Inheritor> FindAll(ref List<Inheritor> inheritors, bool fromChildren = false, bool fromBrother = false, bool fromParent = false, bool? isWomen = null){
        if(this.IsAlive && (isWomen == null || this.isWomen == isWomen)){
            inheritors.Add(this);
        }
        if(!fromChildren && this.Childrens.Count > 0){
            this.Childrens.First().FindAll(ref inheritors, false, false, true, isWomen);
        }

        if(!fromBrother){
            if(this.Parent != null){
                if(this.Parent.Childrens.Count > 1){
                    foreach (var brother in this.Parent.Childrens)
                    {
                        if(brother == this){
                            continue;
                        }
                        brother.FindAll(ref inheritors, false, true, false, isWomen);
                    }
                }
                if(!fromParent){
                    this.Parent.FindAll(ref inheritors, true, false, false, isWomen);
                }
            }

        }
        return inheritors;
    }
}
