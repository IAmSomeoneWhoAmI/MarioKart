using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Characters", menuName = "character")]
public class Characters : ScriptableObject
{
    public string Name;
    

    public GameObject CharacterModel;
}