using System;
using UnityEngine;

public class Button : MonoBehaviour
{
    public event Action OnButtonActivate;
    public event Action OnButtonDisable;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        OnButtonActivate?.Invoke();
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        OnButtonDisable?.Invoke();
    }
}
