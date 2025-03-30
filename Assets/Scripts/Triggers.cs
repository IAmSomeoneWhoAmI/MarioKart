using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Triggers : MonoBehaviour
{
    public bool isFinishLine;

    private void OnTriggerEnter(Collider other)
    {
        var otherLapManager = other.GetComponent<Tour>();
        if (otherLapManager != null)
        {
            otherLapManager.AddCheckPoint(this);
            Debug.Log("checkpoint");
        }
    }
}