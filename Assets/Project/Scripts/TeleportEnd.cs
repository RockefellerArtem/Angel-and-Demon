using System;
using System.Collections;
using System.Collections.Generic;
using Project.Scripts.Level;
using UnityEngine;

public class TeleportEnd : MonoBehaviour
{
    [SerializeField] private LevelManager _levelManager;
    [SerializeField] private LevelHandler _levelHandler;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController>() != null)
        {
            _levelManager.OnHandleExitLevel(_levelHandler);
        }
    }
}
