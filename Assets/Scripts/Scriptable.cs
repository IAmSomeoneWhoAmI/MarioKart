using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scriptable : ScriptableObject
// Start is called before the first frame update
{
    
    
        public Sprite itemSprite;
        public string itemName;
        public int itemUseCount = 1;


        public virtual void Activation(PlayerItemManager player)
        {

        }
    public virtual void Activation(Player2ItemManager player)
    {

    }
}

