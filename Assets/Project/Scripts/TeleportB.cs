using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportB : MonoBehaviour
{
    public Vector3 CoordinateB => _coordinate;

    private Vector3 _coordinate;

    private void Start()
    {
        _coordinate = transform.position;
    }
    
}
