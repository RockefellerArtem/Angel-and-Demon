using System.Collections;
using UnityEngine;

public class ConnectingObject : MonoBehaviour
{
    [SerializeField] float _height;
    [SerializeField] float _time;

    private float _yOpen, _yClose;

    public void OnEnable()
    {
        _yOpen = transform.localScale.y;
        _yClose = transform.localScale.y + _height;

        StartCoroutine(ScaleY(_yOpen, _yClose));
    }

    public void OnButtonDisable()
    {
        StartCoroutine(ScaleY(_yClose, _yOpen));
    }

    public void OnButtonActivate()
    {
        StartCoroutine(ScaleY(_yOpen, _yClose));
    }

    public IEnumerator ScaleY(float startY, float endY)
    {
        float t = 0f;
        while(t <= _time)
        {
            var scale = transform.localScale;
            var position = transform.localPosition;
            scale.y = Mathf.Lerp(startY, endY, t / _time);
            t += Time.deltaTime;
            transform.localScale = scale;
            position.y = -scale.y / 2;
            transform.localPosition = position;
            // Debug.Log(remaining);
            yield return null;
        }
    }
}
