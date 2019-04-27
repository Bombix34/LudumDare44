using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceManager : MonoBehaviour
{
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
        List<Sprite> result = database.GetCharacter(System.Convert.ToBoolean(Random.Range(0,2)));
        mouth.sprite = result[0];
        hair.sprite = result[1];
        hair.color = Random.ColorHSV(0f, 1f, 0f, 1f, 0f, 1f, 1f,1F);
        nose.sprite = result[2];
        face.sprite = result[3];
        eyes.sprite = result[4];
        eyes.color = Random.ColorHSV(0f, 1f, 0f, 1f, 0f, 1f, 1f, 1F);
    }
}
