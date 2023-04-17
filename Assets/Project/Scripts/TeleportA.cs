using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportA : MonoBehaviour
{
    public event Action OnHandlerExit;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            OnHandlerExit?.Invoke();
        }
    }
}
