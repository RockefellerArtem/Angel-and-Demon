using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] float _buttonDownDelta;
    [SerializeField] float _timeDown;

    public event Action OnButtonActivate;
    public event Action OnButtonDisable;

    private bool _isMoving = false;
    private Vector3 _downPosition, _upPosition;

    public void OnEnable()
    {
        _downPosition = transform.position - new Vector3(0f, _buttonDownDelta, 0f);
        _upPosition = transform.position;

        OnButtonActivate += () => { StartCoroutine(Move(_upPosition, _downPosition)); };
        OnButtonDisable += () => { StartCoroutine(Move(_downPosition, _upPosition)); };
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (_isMoving) return;
        OnButtonActivate?.Invoke();
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (_isMoving) return;
        OnButtonDisable?.Invoke();
    }

    public IEnumerator Move(Vector3 startPos, Vector3 endPos)
    {
        _isMoving = true;
        float t = 0f;
        while (t <= _timeDown)
        {
            transform.position = Vector3.Lerp(startPos, endPos, t / _timeDown);
            t += Time.deltaTime;
            yield return null;
        }
        _isMoving = false;
    }
}
