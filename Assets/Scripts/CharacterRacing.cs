using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRacing : MonoBehaviour
{
    private CharacterSelection Selected;
    

    private MeshFilter meshFilter;
    private void Start()
    {
        CharacterSelection[] allSelections = FindObjectsOfType<CharacterSelection>();
        foreach (CharacterSelection selection in allSelections)
        {
            if(selection.tag == this.tag)
            {
                var o = Instantiate(selection.GetChara().CharacterModel,this.transform);
                o.transform.localScale = Vector3.one/30;


            }
        }

    }
}
