using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformState : MonoBehaviour
{
    public event Action<bool> CallbackStatePlatform;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"CollisionStay {other.gameObject.name} ");

        CallbackStatePlatform?.Invoke(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log($"CollisionExit {other.gameObject.name} ");

        CallbackStatePlatform?.Invoke(false);
    }
}
