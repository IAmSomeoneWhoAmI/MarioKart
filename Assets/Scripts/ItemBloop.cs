using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBloop : MonoBehaviour
{
    public void Kiss(GameObject Bloop)
    {
        StartCoroutine(KissRoutine(Bloop));
    }
    private IEnumerator KissRoutine(GameObject Bloop)
    {
        Bloop.SetActive(true);
        yield return new WaitForSeconds(3);
        Bloop.SetActive(false);
    }
}
