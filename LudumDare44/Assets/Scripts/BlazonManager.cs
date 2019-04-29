using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class BlazonManager
{
    public Color UpperLeft { get; set; }
    public Color UpperRight { get; set; }
    public Color LowerLeft { get; set; }
    public Color LowerRight { get; set; }
    public Color MotifColor { get; set; }
    public Sprite Motif { get; set; }

    public void Random(string name){
        var rnd = new System.Random(name.GetHashCode());
        int r = rnd.Next(ColorManager.Instance.BlazonColor.colors.Count);
        this.UpperLeft = ColorManager.Instance.BlazonColor.colors[r];
        r = rnd.Next(ColorManager.Instance.BlazonColor.colors.Count);
        this.UpperRight = ColorManager.Instance.BlazonColor.colors[r];
        r = rnd.Next(ColorManager.Instance.BlazonColor.colors.Count);
        this.LowerLeft = ColorManager.Instance.BlazonColor.colors[r];
        r = rnd.Next(ColorManager.Instance.BlazonColor.colors.Count);
        this.LowerRight = ColorManager.Instance.BlazonColor.colors[r];
        r = rnd.Next(ColorManager.Instance.BlazonColor.colors.Count);
        this.MotifColor = ColorManager.Instance.BlazonColor.colors[r];
        r = rnd.Next(GameManager.Instance.BlazonDatabase.Blazons.Count);
        this.Motif = GameManager.Instance.BlazonDatabase.Blazons[r];
    }
}
