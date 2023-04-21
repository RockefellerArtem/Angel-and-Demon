using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonForFan : MonoBehaviour
{
    [SerializeField] private WindGenerator _windGenerator;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"CollisionStay {other.gameObject.name} ");

        _windGenerator.TurnOn();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log($"CollisionExit {other.gameObject.name} ");

        _windGenerator.TurnOff();
    }
}
