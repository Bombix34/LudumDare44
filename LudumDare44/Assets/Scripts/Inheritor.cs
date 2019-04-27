using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inheritor
{
    public string Name { get; set; }
    public bool isWomen { get; set; }
    public bool Reigning { get; set; }
    public Inheritor Spouse { get; set; }

    public Inheritor Parent { get; set; }
    public List<Inheritor> Childrens { get; set; }
}
