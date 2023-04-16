using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportController : MonoBehaviour
{
    [SerializeField] private Transform _player;
    
    [SerializeField] private TeleportA _pointA;
    [SerializeField] private TeleportB _pointB;
    [SerializeField] private TeleportEnd _pointEnd;

    private void OnEnable()
    {
        _pointA.OnHandlerExit += Translate;
    }

    private void Translate()
    {
        _player.position = _pointB.CoordinateB;
    }
}
