using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    [SerializeField] float _buttonDownDelta;
    [SerializeField] float _timeDown;
    [SerializeField] List<UnityEvent> _onButtonEnable;
    [SerializeField] List<UnityEvent> _onButtonDisable;

    private bool _isMoving = false;
    private Vector3 _downPosition, _upPosition;

    public void OnEnable()
    {
        _downPosition = transform.position - new Vector3(0f, _buttonDownDelta, 0f);
        _upPosition = transform.position;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (_isMoving) return;
        StartCoroutine(Move(_upPosition, _downPosition));

        foreach(var action in _onButtonEnable)
        {
            action?.Invoke();
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (_isMoving) return;
        StartCoroutine(Move(_downPosition, _upPosition));

        foreach (var action in _onButtonDisable)
        {
            action?.Invoke();
        }
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
