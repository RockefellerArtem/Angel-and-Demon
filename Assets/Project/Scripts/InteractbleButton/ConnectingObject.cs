using System.Collections;
using UnityEngine;

public class ConnectingObject : MonoBehaviour
{
    [SerializeField] Button _button;
    [SerializeField] float _height;
    [SerializeField] float _time;

    public void OnEnable()
    {
        _button.OnButtonActivate += OnButtonActivate;
        _button.OnButtonDisable += OnButtonDisable;
    }

    private void OnButtonDisable()
    {
        StartCoroutine(ScaleY(-_height));
    }

    public void OnButtonActivate()
    {
        StartCoroutine(ScaleY(_height));
    }

    public IEnumerator ScaleY(float coeff)
    {
        float t = 0f;
        while(t <= _time)
        {
            var scale = transform.localScale;
            var position = transform.localPosition;
            scale.y += coeff / _time * Time.deltaTime;
            t += Time.deltaTime;
            transform.localScale = scale;
            position.y = -scale.y / 2;
            transform.localPosition = position;
            // Debug.Log(remaining);
            yield return null;
        }
    }
}
