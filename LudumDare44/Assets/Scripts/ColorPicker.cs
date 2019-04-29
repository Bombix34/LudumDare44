using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "LD44/Color picker")]
public class ColorPicker : ScriptableObject
{
    [SerializeField]
    public List<Color> colors;

    public Color GetRandColor()
    {
        return colors[(int)Random.Range(0f, colors.Count)];
    }
}
