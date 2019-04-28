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
