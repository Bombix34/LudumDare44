using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceManager : MonoBehaviour
{

    List<Sprite> sprites;
    List<DuoGraphicElement> renderSprite;
  //  List<SpriteRenderer> rendererSprite;

    [SerializeField]
    FaceDatabase database;

    [SerializeField]
    SpriteRenderer mouth;
    [SerializeField]
    SpriteRenderer hair;
    [SerializeField]
    SpriteRenderer nose;
    [SerializeField]
    SpriteRenderer face;
    [SerializeField]
    SpriteRenderer eyes;
    [SerializeField]
    SpriteRenderer sourcils;
    [SerializeField]
    SpriteRenderer barbe;
    [SerializeField]
    SpriteRenderer buste;

    [SerializeField]
    SpriteRenderer background;

    CharacterManager manager;

    // mouth -> 0
    // hair -> 1
    // nose -> 2
    // face -> 3
    // eyes -> 4
    // sourcils -> 5
    // barbes -> 6
    // buste -> 7
    FaceAnimation faceAnimation;

    void Awake()
    {
        faceAnimation = GetComponent<FaceAnimation>();
    }

    private void Start()
    {
    }

    public void InitRandomFace(bool isWoman)
    {
        sprites = database.GetCharacter(isWoman);

        Color hairColor = ColorManager.Instance.HairColor.GetRandColor();
        Color eyesColor = ColorManager.Instance.EyesColor.GetRandColor();
        Color faceColor = ColorManager.Instance.SkinColor.GetRandColor();
        Color noseColor = ColorManager.Instance.NoseColor.GetRandColor()*faceColor;
        Color mouthColor = ColorManager.Instance.MouthColor.GetRandColor();

        mouth.sprite = sprites[0];
        mouth.color = mouthColor;

        manager.CharacterInfos.pairSpriteColor.Add(new DuoGraphicElement(mouth.sprite, mouth.color));

        hair.sprite = sprites[1];
        hair.color = hairColor;

        manager.CharacterInfos.pairSpriteColor.Add(new DuoGraphicElement(hair.sprite, hair.color));

        nose.sprite = sprites[2];
        nose.color = noseColor;

        manager.CharacterInfos.pairSpriteColor.Add(new DuoGraphicElement(nose.sprite, nose.color));

        face.sprite = sprites[3];
        face.color = faceColor;

        manager.CharacterInfos.pairSpriteColor.Add(new DuoGraphicElement(face.sprite, face.color));

        eyes.sprite = sprites[4];
        eyes.color = eyesColor;

        manager.CharacterInfos.pairSpriteColor.Add(new DuoGraphicElement(eyes.sprite, eyes.color));

        sourcils.sprite = sprites[5];
        sourcils.color = hairColor;

        manager.CharacterInfos.pairSpriteColor.Add(new DuoGraphicElement(hair.sprite, hair.color));

        barbe.sprite = sprites[6];
        barbe.color = hairColor;

        manager.CharacterInfos.pairSpriteColor.Add(new DuoGraphicElement(barbe.sprite, barbe.color));

        buste.sprite = sprites[7];  
        buste.color = faceColor;

        manager.CharacterInfos.pairSpriteColor.Add(new DuoGraphicElement(buste.sprite, buste.color));
    }

    public void InitHeritanceFace()
    {
        bool isWoman = manager.CharacterInfos.isWomen;
        List<DuoGraphicElement> momFace = manager.CharacterInfos.Parent.isWomen ? manager.CharacterInfos.Parent.pairSpriteColor : manager.CharacterInfos.Parent.Spouse.pairSpriteColor;
        List<DuoGraphicElement> dadFace = !manager.CharacterInfos.Parent.isWomen ? manager.CharacterInfos.Parent.pairSpriteColor : manager.CharacterInfos.Parent.Spouse.pairSpriteColor;
        List<Sprite> randomFace = database.GetCharacter(isWoman);

        Color randFaceColor = ColorManager.Instance.SkinColor.GetRandColor();
        Color randNoseColor = ColorManager.Instance.NoseColor.GetRandColor() * randFaceColor;


        //BOUCHE______________________________
        int rand = (int)Random.Range(0f, 99f);
        if (isWoman)
        {
            if (rand < 80)
                mouth.sprite = momFace[0].Sprite;
            else
                mouth.sprite = randomFace[0];
        }
        else
        {
            if (rand < 80)
                mouth.sprite = dadFace[0].Sprite;
            else
                mouth.sprite = randomFace[0];
        }
        rand = (int)Random.Range(0f, 99f);
        if (rand < 45)
        {
            mouth.color = momFace[0].ElementColor;
        }
        else if (rand < 90)
        {
            mouth.color = dadFace[0].ElementColor;
        }
        else
        {
            mouth.color = ColorManager.Instance.MouthColor.GetRandColor();
        }
        manager.CharacterInfos.pairSpriteColor.Add(new DuoGraphicElement(mouth.sprite, mouth.color));

        //CHEVEUX____________________________
        rand = (int)Random.Range(0f, 99f);
        if (isWoman)
        {
            if (rand < 80)
                hair.sprite = momFace[1].Sprite;
            else
                hair.sprite = randomFace[1];
        }
        else
        {
            if (rand < 80)
                hair.sprite = dadFace[1].Sprite;
            else
                hair.sprite = randomFace[1];
        }
        rand = (int)Random.Range(0f, 99f);
        if (rand < 45)
        {
            hair.color = momFace[1].ElementColor;
        }
        else if (rand < 90)
        {
            hair.color = dadFace[1].ElementColor;
        }
        else
        {
            hair.color = ColorManager.Instance.HairColor.GetRandColor();
        }
        manager.CharacterInfos.pairSpriteColor.Add(new DuoGraphicElement(hair.sprite, hair.color));
        //NEZ_______________________________
        rand = (int)Random.Range(0f, 99f);
        if (isWoman)
        {
            if (rand < 80)
                nose.sprite = momFace[2].Sprite;
            else
                nose.sprite = randomFace[2];
        }
        else
        {
            if (rand < 80)
                nose.sprite = dadFace[2].Sprite;
            else
                nose.sprite = randomFace[2];
        }
        rand = (int)Random.Range(0f, 99f);
        if (rand < 45)
        {
            nose.color = momFace[2].ElementColor;
        }
        else if (rand < 90)
        {
            nose.color = dadFace[2].ElementColor;
        }
        else
        {
            nose.color = randNoseColor;
        }
        manager.CharacterInfos.pairSpriteColor.Add(new DuoGraphicElement(nose.sprite, nose.color));
        //VISAGE_______________________________
        rand = (int)Random.Range(0f, 99f);
        if (isWoman)
        {
            if (rand < 80)
                face.sprite = momFace[3].Sprite;
            else
                face.sprite = randomFace[3];
        }
        else
        {
            if (rand < 80)
                face.sprite = dadFace[3].Sprite;
            else
                face.sprite = randomFace[3];
        }
        if (nose.color == randNoseColor)
        {
            face.color = randFaceColor;
        }
        else if (nose.color == momFace[2].ElementColor)
        {
            face.color = momFace[3].ElementColor;
        }
        else if (nose.color == dadFace[2].ElementColor)
        { 
            face.color = dadFace[3].ElementColor;
        }
        manager.CharacterInfos.pairSpriteColor.Add(new DuoGraphicElement(face.sprite, face.color));
        //YEUX_______________________________
        rand = (int)Random.Range(0f, 99f);
        if (isWoman)
        {
            if (rand < 80)
                eyes.sprite = momFace[4].Sprite;
            else
                eyes.sprite = randomFace[4];
        }
        else
        {
            if (rand < 80)
                eyes.sprite = dadFace[4].Sprite;
            else
                eyes.sprite = randomFace[4];
        }
        rand = (int)Random.Range(0f, 99f);
        if (rand < 45)
        {
            eyes.color = momFace[4].ElementColor;
        }
        else if (rand < 90)
        {
            eyes.color = dadFace[4].ElementColor;
        }
        else
        {
            eyes.color = ColorManager.Instance.EyesColor.GetRandColor();
        }
        manager.CharacterInfos.pairSpriteColor.Add(new DuoGraphicElement(eyes.sprite, eyes.color));
        //SOURCILS__________________________________________
        rand = (int)Random.Range(0f, 99f);
        if (isWoman)
        {
            if (rand < 80)
                sourcils.sprite = momFace[5].Sprite;
            else
                sourcils.sprite = randomFace[5];
        }
        else
        {
            if (rand < 80)
                sourcils.sprite = dadFace[5].Sprite;
            else
                sourcils.sprite = randomFace[5];
        }
        sourcils.color = hair.color;
        manager.CharacterInfos.pairSpriteColor.Add(new DuoGraphicElement(sourcils.sprite, sourcils.color));
        //BARBES_______________________________________
        rand = (int)Random.Range(0f, 99f);
        if (isWoman)
        {
            barbe.sprite = null;
        }
        else
        {
            if (rand < 80)
                barbe.sprite = dadFace[6].Sprite;
            else
                barbe.sprite = randomFace[6];
        }
        barbe.color = hair.color;
        manager.CharacterInfos.pairSpriteColor.Add(new DuoGraphicElement(barbe.sprite, barbe.color));
        //BUSTE_______________________________________
        rand = (int)Random.Range(0f, 99f);
        if (isWoman)
        {
            if (rand < 80)
                buste.sprite = momFace[7].Sprite;
            else
                buste.sprite = randomFace[7];
        }
        else
        {
            if (rand < 80)
                buste.sprite = dadFace[7].Sprite;
            else
                buste.sprite = randomFace[7];
        }
        buste.color = face.color;
        manager.CharacterInfos.pairSpriteColor.Add(new DuoGraphicElement(buste.sprite, buste.color));

    }

    public void DieFeedback()
    {
        if (manager.CharacterInfos.IsAlive)
            return;
        // mouth -> 0
        // hair -> 1
        // nose -> 2
        // face -> 3
        // eyes -> 4
        // sourcils -> 5
        // barbes -> 6
        // buste -> 7
        mouth.color = Color.white;
        hair.color = Color.white;
        nose.color = Color.black;
        face.color = Color.white;
        eyes.sprite = null;
        sourcils.color = Color.white;
        barbe.color = Color.white;
        buste.color = Color.white;
        background.color = Color.gray;
        faceAnimation.StopAnim();
    }

    public List<Sprite> GetFace()
    {
        return sprites;
    }

    public List<DuoGraphicElement> GetFaceWithColor()
    {
        return manager.CharacterInfos.pairSpriteColor;
    }

    public CharacterManager Manager
    {
        get
        {
            return manager;
        }
        set
        {
            manager = value;
        }
    }
}
