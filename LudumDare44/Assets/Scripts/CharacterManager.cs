using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public Inheritor CharacterInfos { get; set; }
    
    public BlazonManager BlazonManager { get; set; }
    public Blazon2d Blazon2d { get; set; }

    [SerializeField] FaceManager face;

    private void Awake()
    {
        face = GetComponentInChildren<FaceManager>();
        Blazon2d = GetComponentsInChildren<Blazon2d>().Where(q => q.transform.parent.parent == this.transform).First();
        face.Manager = this;
        print(Blazon2d.transform.parent.parent.gameObject);
    }

    public void Init(Inheritor concerned)
    {
        CharacterInfos = concerned;
        Face.Manager = this;
        concerned.Manager = this;
        BlazonManager = new BlazonManager();
        BlazonManager.Random(CharacterInfos.FamilyName);
        Blazon2d.BlazonManager = BlazonManager;
        Blazon2d.UpdateBlazon();
    }

    public FaceManager Face
    {
        get
        {
            return face;
        }
    }

}
