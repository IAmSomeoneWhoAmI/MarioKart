using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSelection : MonoBehaviour
{
    public Transform target;

    void FixedUpdate()
    {
        transform.LookAt(target);
        transform.Translate(Vector3.right * 50*Time.deltaTime);
    }
}
