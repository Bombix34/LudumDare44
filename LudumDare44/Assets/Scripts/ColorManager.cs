using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    [SerializeField]
    public ColorPicker EyesColor;
    [SerializeField]
    public ColorPicker HairColor;
    [SerializeField]
    public ColorPicker MouthColor;
    [SerializeField]
    public ColorPicker NoseColor;
    [SerializeField]
    public ColorPicker SkinColor;


    //SINGLETON________________________________________________________________________________________________
    private static ColorManager s_Instance = null;

    // This defines a static instance property that attempts to find the manager object in the scene and
    // returns it to the caller.
    public static ColorManager instance
    {
        get
        {
            if (s_Instance == null)
            {
                // This is where the magic happens.
                //  FindObjectOfType(...) returns the first AManager object in the scene.
                s_Instance = FindObjectOfType(typeof(ColorManager)) as ColorManager;
            }

            // If it is still null, create a new instance
            if (s_Instance == null)
            {
                Debug.Log("error");
                GameObject obj = new GameObject("Error");
                s_Instance = obj.AddComponent(typeof(ColorManager)) as ColorManager;
            }

            return s_Instance;
        }
    }
}
