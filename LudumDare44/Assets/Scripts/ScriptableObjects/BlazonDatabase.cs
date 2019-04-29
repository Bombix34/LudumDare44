using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "LD44/BlazonDataBase")]
public class BlazonDatabase : ScriptableObject
{
    [SerializeField]
    public List<Sprite> Blazons;
}
