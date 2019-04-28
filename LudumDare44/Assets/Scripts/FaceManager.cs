using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceManager : MonoBehaviour
{

    List<Sprite> sprites;
    List<SpriteRenderer> rendererSprite;

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

    void Awake()
    {
        InitRendererList();
    }

    private void Start()
    {
    }

    public void InitRandomFace()
    {
        sprites = database.GetCharacter(System.Convert.ToBoolean(Random.Range(0,2)));

        Color hairColor = ColorManager.instance.HairColor.GetRandColor();
        Color eyesColor = ColorManager.instance.EyesColor.GetRandColor();
        Color faceColor = ColorManager.instance.SkinColor.GetRandColor();
        Color noseColor = ColorManager.instance.NoseColor.GetRandColor()*faceColor;
        Color mouthColor = ColorManager.instance.MouthColor.GetRandColor();

        mouth.sprite = sprites[0];
        mouth.color = mouthColor;

        hair.sprite = sprites[1];
        hair.color = hairColor;

        nose.sprite = sprites[2];
        nose.color = noseColor;

        face.sprite = sprites[3];
        face.color = faceColor;

        eyes.sprite = sprites[4];
        eyes.color = eyesColor;

        sourcils.sprite = sprites[5];
        sourcils.color = hairColor;

        barbe.sprite = sprites[6];
        barbe.color = hairColor;

        buste.sprite = sprites[7];
        buste.color = faceColor;

        manager.CharacterInfos.RendererFaces = rendererSprite;
    }

    public void InitRendererList()
    {
        rendererSprite = new List<SpriteRenderer>();
        rendererSprite.Add(mouth);
        rendererSprite.Add(hair);
        rendererSprite.Add(nose);
        rendererSprite.Add(face);
        rendererSprite.Add(eyes);
        rendererSprite.Add(sourcils);
        rendererSprite.Add(barbe);
        rendererSprite.Add(buste);
    }

    public void InitSpriteRendererAccess(CharacterManager charac)
    {
        InitRendererList();
        manager = charac;
        manager.CharacterInfos.RendererFaces = rendererSprite;
    }

    public void InitHeritanceFace()
    {
        List<SpriteRenderer> momFace = manager.CharacterInfos.Parent.isWomen ? manager.CharacterInfos.Parent.RendererFaces : manager.CharacterInfos.Parent.Spouse.RendererFaces;
        List<SpriteRenderer> dadFace = !manager.CharacterInfos.Parent.isWomen ? manager.CharacterInfos.Parent.RendererFaces : manager.CharacterInfos.Parent.Spouse.RendererFaces;
        List<Sprite> randomFace = database.GetCharacter(!manager.CharacterInfos.isWomen);

        Color randFaceColor = ColorManager.instance.SkinColor.GetRandColor();
        Color randNoseColor = ColorManager.instance.NoseColor.GetRandColor() * randFaceColor;

        //BOUCHE______________________________
        int rand = (int)Random.Range(0f, 99f);
        if (manager.CharacterInfos.isWomen)
        {
            if(rand<80)
                mouth.sprite = momFace[0].sprite;
            else
                mouth.sprite = randomFace[0];
        }
        else
        {
            if (rand < 80)
                mouth.sprite = dadFace[0].sprite;
            else
                mouth.sprite = randomFace[0];
        }
        rand = (int)Random.Range(0f, 99f);
        if(rand<45)
        {
            mouth.color = momFace[0].color;
        }else if(rand<90)
        {
            mouth.color = dadFace[0].color;
        }else
        {
            mouth.color = ColorManager.instance.MouthColor.GetRandColor();
        }
        //CHEVEUX____________________________
        rand = (int)Random.Range(0f, 99f);
        if (manager.CharacterInfos.isWomen)
        {
            if (rand < 80)
                hair.sprite = momFace[1].sprite;
            else
                hair.sprite = randomFace[1];
        }
        else
        {
            if (rand < 80)
                hair.sprite = dadFace[1].sprite;
            else
                hair.sprite = randomFace[1];
        }
        rand = (int)Random.Range(0f, 99f);
        if (rand < 45)
        {
            hair.color = momFace[1].color;
        }
        else if (rand < 90)
        {
            hair.color = dadFace[1].color;
        }
        else
        {
            hair.color = ColorManager.instance.HairColor.GetRandColor();
        }
        //NEZ_______________________________
        rand = (int)Random.Range(0f, 99f);
        if (manager.CharacterInfos.isWomen)
        {
            if (rand < 80)
                nose.sprite = momFace[2].sprite;
            else
                nose.sprite = randomFace[2];
        }
        else
        {
            if (rand < 80)
                nose.sprite = dadFace[2].sprite;
            else
                nose.sprite = randomFace[2];
        }
        rand = (int)Random.Range(0f, 99f);
        if (rand < 45)
        {
            nose.color = momFace[2].color;
        }
        else if (rand < 90)
        {
            nose.color = dadFace[2].color;
        }
        else
        {
            nose.color = randNoseColor;
        }
        //VISAGE_______________________________
        rand = (int)Random.Range(0f, 99f);
        if (manager.CharacterInfos.isWomen)
        {
            if (rand < 80)
                face.sprite = momFace[3].sprite;
            else
                face.sprite = randomFace[3];
        }
        else
        {
            if (rand < 80)
                face.sprite = dadFace[3].sprite;
            else
                face.sprite = randomFace[3];
        }
        if (nose.color == randNoseColor)
        {
            face.color = randFaceColor;
        }
        else
        {
            rand = (int)Random.Range(0f, 99f);
            if (rand < 45)
            {
                face.color = momFace[3].color;
            }
            else if (rand < 90)
            {
                face.color = dadFace[3].color;
            }
            else
            {
                face.color = randFaceColor;
            }
        }
        //YEUX_______________________________
        rand = (int)Random.Range(0f, 99f);
        if (manager.CharacterInfos.isWomen)
        {
            if (rand < 80)
                eyes.sprite = momFace[4].sprite;
            else
                eyes.sprite = randomFace[4];
        }
        else
        {
            if (rand < 80)
                eyes.sprite = dadFace[4].sprite;
            else
                eyes.sprite = randomFace[4];
        }
        rand = (int)Random.Range(0f, 99f);
        if (rand < 45)
        {
            eyes.color = momFace[4].color;
        }
        else if (rand < 90)
        {
            eyes.color = dadFace[4].color;
        }
        else
        {
            eyes.color = ColorManager.instance.EyesColor.GetRandColor();
        }
        //SOURCILS__________________________________________
        rand = (int)Random.Range(0f, 99f);
        if (manager.CharacterInfos.isWomen)
        {
            if (rand < 80)
                sourcils.sprite = momFace[5].sprite;
            else
                sourcils.sprite = randomFace[5];
        }
        else
        {
            if (rand < 80)
                sourcils.sprite = dadFace[5].sprite;
            else
                sourcils.sprite = randomFace[5];
        }
        sourcils.color = hair.color;
        //BARBES_______________________________________
        rand = (int)Random.Range(0f, 99f);
        if (manager.CharacterInfos.isWomen)
        {
            barbe.sprite = null;
        }
        else
        {
            if (rand < 80)
                barbe.sprite = dadFace[6].sprite;
            else
                barbe.sprite = randomFace[6];
        }
        barbe.color = hair.color;
        //BUSTE_______________________________________
        rand = (int)Random.Range(0f, 99f);
        if (manager.CharacterInfos.isWomen)
        {
            if (rand < 80)
                buste.sprite = momFace[7].sprite;
            else
                buste.sprite = randomFace[7];
        }
        else
        {
            if (rand < 80)
                buste.sprite = dadFace[7].sprite;
            else
                buste.sprite = randomFace[7];
        }
        buste.color = face.color;
    }

    public List<Sprite> GetFace()
    {
        return sprites;
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
