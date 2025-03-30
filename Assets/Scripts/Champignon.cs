using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemChampi", menuName ="Scriptable Objects/ItemChampi")]
public class Champignon : Scriptable
{
    public override void Activation(PlayerItemManager player)
    {
        player.carControler.Turbo();
    }
    public override void Activation(Player2ItemManager player)
    {
        player.carControler.Turbo();
    }
}