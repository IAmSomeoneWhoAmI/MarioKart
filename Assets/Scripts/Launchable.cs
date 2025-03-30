using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemLaunchable", menuName = "Scriptable Objects/ItemLaunchable")]
public class Launchable : Scriptable
{
    public GameObject objectToLaunch;

    public override void Activation(PlayerItemManager player)
    {
        Instantiate(objectToLaunch, player.transform.position, player.transform.rotation);
    }
    public override void Activation(Player2ItemManager player)
    {
        Instantiate(objectToLaunch, player.transform.position, player.transform.rotation);
    }

}
