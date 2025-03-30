using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    public Characters[] select;
    public Transform Spot;

    [SerializeField]
    private List<GameObject> characters;
    private int currentCharacter;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        characters = new List<GameObject>();

        foreach (var select in select)
        {
            GameObject go = Instantiate(select.CharacterModel, Spot.position, Quaternion.identity);
            go.SetActive(false);
            go.transform.SetParent(Spot);
            characters.Add(go);
        }

        ShowCharFromList();
    }

    

    void ShowCharFromList()
    {
        characters[currentCharacter].SetActive(true);
    }

    public void OnClickNext()
    {
        characters[currentCharacter].SetActive(false);

        if(currentCharacter < characters.Count - 1)
            currentCharacter = currentCharacter + 1;
        else
            currentCharacter = 0;
        ShowCharFromList();
    }
    public void OnClickPrev()
    {
        characters[currentCharacter].SetActive(false);

        if (currentCharacter == 0)
            currentCharacter = characters.Count - 1;    
        else
            currentCharacter = currentCharacter - 1;
        ShowCharFromList();
    }

    public Characters GetChara()
    {
        return select[currentCharacter];
    }
}
