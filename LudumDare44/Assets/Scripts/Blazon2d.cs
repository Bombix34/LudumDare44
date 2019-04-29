using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blazon2d : MonoBehaviour
{
    public BlazonManager BlazonManager;
    public SpriteRenderer UpperLeft;
    public SpriteRenderer UpperRight;
    public SpriteRenderer LowerLeft;
    public SpriteRenderer LowerRight;
    public SpriteRenderer Motif;
    // Start is called before the first frame update
    public void UpdateBlazon()
    {
        UpperLeft.color = BlazonManager.UpperLeft;
        UpperRight.color = BlazonManager.UpperRight;
        LowerLeft.color = BlazonManager.LowerLeft;
        LowerRight.color = BlazonManager.LowerRight;
        Motif.color = BlazonManager.MotifColor;
        Motif.sprite = BlazonManager.Motif;
    }
}
