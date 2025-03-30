using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tour : MonoBehaviour
{
    private int _lapNumber;
    
    private List<Triggers> _checkpoints;
    private int _numberOfCheckpoints;


    private void Start()
    {
        _numberOfCheckpoints = FindObjectsByType<Triggers>(FindObjectsSortMode.None).Length;
        _checkpoints = new List<Triggers>();
    }

    public void AddCheckPoint(Triggers checkPointToAdd)
    {
        if (checkPointToAdd.isFinishLine)
        {
            FinishLap();
        }

        if (_checkpoints.Contains(checkPointToAdd) == false)
        {
            _checkpoints.Add(checkPointToAdd);
        }
    }

    private void FinishLap()
    {
        if (_checkpoints.Count > _numberOfCheckpoints / 2)
        {
            _lapNumber++;
            Debug.Log("Tour Fini, on entre dans le tour " + _lapNumber);
            _checkpoints.Clear();
            if (_lapNumber >= 3)
            {
                Debug.Log("Gg WP");
            }
        }
    }
}