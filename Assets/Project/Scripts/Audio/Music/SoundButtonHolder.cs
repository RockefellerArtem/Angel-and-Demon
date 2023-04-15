using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundButtonHolder : MonoBehaviour
{
    [SerializeField] private Image _icon;
    
    [SerializeField] private Sprite _on;
    [SerializeField] private Sprite _off;

    [SerializeField] private UnityEngine.UI.Button _button;

    public event Action OnClickSoundButton; 
    
    private void Start()
    {
        _button.onClick.AddListener(HandlerClickButton);
    }

    private void HandlerClickButton()
    {
        OnClickSoundButton?.Invoke();
    }

    public void SetIcon(bool isStatus)
    {
        if (isStatus) _icon.sprite = _on;
        else _icon.sprite = _off;
    }
}
