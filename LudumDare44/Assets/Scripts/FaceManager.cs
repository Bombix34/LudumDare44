using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceManager : MonoBehaviour
{

    List<Sprite> sprites;

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

    // mouth -> 0
    // hair -> 1
    // nose -> 2
    // face -> 3
    // eyes -> 4
    // sourcils -> 5
    // barbes -> 6
    // buste -> 7

    void Start()
    {
        InitRandomFace();
    }

    void Update()
    {
        if(Input.GetKeyDown("r"))
        {
            InitRandomFace();
        }
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
    }

    public List<Sprite> GetFace()
    {
        return sprites;
    }
}
