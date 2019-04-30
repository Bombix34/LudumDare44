using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeddingManager : MonoBehaviour
{
    public WeddingReglages reglages;
    public CharacterPool characterPool;

    public FaceDatabase faceDatabase;

    WeddingUI ui;

    [SerializeField]
    List<Inheritor> menWedding;
    [SerializeField]
    List<Inheritor> womenWedding;

    private void Awake()
    {
        menWedding = new List<Inheritor>();
        womenWedding = new List<Inheritor>();
        ui = WeddingUI.Instance;
    }

    private void Start()
    {
        UpdatePool();
    }

    public void UpdatePool()
    {
        for(int i = 0; i < reglages.poolNb;i++)
        {
            if(menWedding.Count<reglages.poolNb)
            {
                Inheritor result = characterPool.GetCharacterWithoutFace(false);
                InitRandomFace(result);
                menWedding.Add(result);
            }
            if(womenWedding.Count<reglages.poolNb)
            {
                Inheritor result = characterPool.GetCharacterWithoutFace(true);
                InitRandomFace(result);
                womenWedding.Add(result);
            }
        }
    }

    public void LaunchWedding(Inheritor concerned)
    {
        UpdatePool();
        if (concerned.isWomen)
            ui.ShowWeddingPanel(true, concerned, menWedding);
        else
            ui.ShowWeddingPanel(true, concerned, womenWedding);
    }

    public void RemoveFromPool(Inheritor concerned)
    {
        if(concerned.isWomen)
        {
            womenWedding.Remove(concerned);
        }
        else
        {
            menWedding.Remove(concerned);
        }
    }

    public void UpdatePoolAge()
    {
        List<Inheritor> toRemove = new List<Inheritor>();
        foreach (var item in menWedding)
        {
            item.Age += 8;

            if (item.Age > 50)
            {
                if (item.Age > 70)
                    toRemove.Add(item);
                else
                {
                    int rand = (int)UnityEngine.Random.Range(0f, 99f);
                    if (rand <= 49)
                        toRemove.Add(item);
                }
            }
        }
        foreach (var item in womenWedding)
        {
            item.Age += 8;

            if (item.Age > 50)
            {
                if (item.Age > 70)
                    toRemove.Add(item);
                else
                {
                    int rand = (int)UnityEngine.Random.Range(0f, 99f);
                    if (rand <= 49)
                        toRemove.Add(item);
                }
            }
        }
        foreach(var item in toRemove)
        {
            RemoveFromPool(item);
        }
        UpdatePool();
    }

    public void InitRandomFace(Inheritor concerned)
    {
        List<Sprite> sprites = faceDatabase.GetCharacter(concerned.isWomen);

        Color hairColor = ColorManager.Instance.HairColor.GetRandColor();
        Color eyesColor = ColorManager.Instance.EyesColor.GetRandColor();
        Color faceColor = ColorManager.Instance.SkinColor.GetRandColor();
        Color noseColor = ColorManager.Instance.NoseColor.GetRandColor() * faceColor;
        Color mouthColor = ColorManager.Instance.MouthColor.GetRandColor();

        concerned.pairSpriteColor.Add(new DuoGraphicElement(sprites[0], mouthColor)); //bouche
        concerned.pairSpriteColor.Add(new DuoGraphicElement(sprites[1], hairColor)); //cheveux 
        concerned.pairSpriteColor.Add(new DuoGraphicElement(sprites[2], noseColor)); //nez
        concerned.pairSpriteColor.Add(new DuoGraphicElement(sprites[3], faceColor));  //visage 

        concerned.pairSpriteColor.Add(new DuoGraphicElement(sprites[4], eyesColor)); //yeux

        concerned.pairSpriteColor.Add(new DuoGraphicElement(sprites[5], hairColor)); //sourcils 
        concerned.pairSpriteColor.Add(new DuoGraphicElement(sprites[6], hairColor)); //barbe

        concerned.pairSpriteColor.Add(new DuoGraphicElement(sprites[7], faceColor)); //buste
    }


}
