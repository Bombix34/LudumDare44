using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "LD44/Character Pool")]
public class CharacterPool : ScriptableObject
{
    public List<string> name;
    public List<string> familyName;

    public Inheritor GetCharacterWithoutFace(bool isWoman)
    {
        Inheritor returnCharacter = new Inheritor();
        returnCharacter.Name = name[(int)Random.Range(0f, name.Count)];
        returnCharacter.FamilyName = familyName[(int)Random.Range(0f,familyName.Count)];
        returnCharacter.Age = (int)Random.Range(10f, 40f);
        returnCharacter.isWomen = isWoman;
        returnCharacter.IsAlive = true;
        returnCharacter.NotBornYet = false;
        return returnCharacter;
    }
}
