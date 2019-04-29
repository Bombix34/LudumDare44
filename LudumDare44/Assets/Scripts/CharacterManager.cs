using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public Inheritor CharacterInfos { get; set; }

    [SerializeField] FaceManager face;

    private void Awake()
    {
        face = GetComponentInChildren<FaceManager>();
        face.Manager = this;
    }

    public void Init(Inheritor concerned)
    {
        CharacterInfos = concerned;
        Face.Manager = this;
        CharacterInfos.Manager = this;
    }

    public FaceManager Face
    {
        get
        {
            return face;
        }
    }

}
