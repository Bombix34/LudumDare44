using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "LD44/FaceDataBase")]
public class FaceDatabase : ScriptableObject
{
    [SerializeField]
    List<Sprite> facesMen;
    [SerializeField]
    List<Sprite> eyesMen;
    [SerializeField]
    List<Sprite> hairMen;
    [SerializeField]
    List<Sprite> mustaches;
    [SerializeField]
    List<Sprite> sourcilsMen;
    [SerializeField]
    List<Sprite> busteMen;
    //  [SerializeField]
    //  List<Sprite> mouthsMen;

    [SerializeField]
    List<Sprite> facesWomen;
    [SerializeField]
    List<Sprite> eyesWomen;
    [SerializeField]
    List<Sprite> hairWomen;
    [SerializeField]
    List<Sprite> sourcilsWomen;
    [SerializeField]
    List<Sprite> busteWomen;

    [SerializeField]
    List<Sprite> mouths;
  //  List<Sprite> mouthsWomen;

    [SerializeField]
    List<Sprite> nose;

    public List<Sprite> GetCharacter(bool isMan)
    {
        int rand = (int) Random.Range(0f, 99f);
        List<Sprite> result = new List<Sprite>();

        result.Add(mouths[(int)Random.Range(0f, mouths.Count)]);
        // result.Add(isMan? mouthsMen[(int)Random.Range(0f,mouthsMen.Count)] : mouthsWomen[(int)Random.Range(0f, mouthsWomen.Count)]);
        if(rand<15)
            result.Add(isMan ? null : hairWomen[(int)Random.Range(0f, hairWomen.Count)]);
        else
            result.Add(isMan ? hairMen[(int)Random.Range(0f, hairMen.Count)] : hairWomen[(int)Random.Range(0f, hairWomen.Count)]);

        result.Add(nose[(int)Random.Range(0f,nose.Count)]);
        result.Add(isMan ? facesMen[(int)Random.Range(0f, facesMen.Count)] : facesWomen[(int)Random.Range(0f, facesWomen.Count)]);
        result.Add(isMan ? eyesMen[(int)Random.Range(0f, eyesMen.Count)] : eyesWomen[(int)Random.Range(0f, eyesWomen.Count)]);
        result.Add(isMan ? sourcilsMen[(int)Random.Range(0f, sourcilsMen.Count)] : sourcilsWomen[(int)Random.Range(0f, sourcilsWomen.Count)]);

        rand = (int)Random.Range(0f, 99f);
        if (rand < (100 / (mustaches.Count + 1)))
            result.Add(null);
        else
            result.Add(isMan ? mustaches[(int)Random.Range(0f, mustaches.Count)] : null);

        result.Add(isMan ? busteMen[(int)Random.Range(0f, busteMen.Count)] : busteWomen[(int)Random.Range(0f, busteWomen.Count)]);

        return result;
    }

}
