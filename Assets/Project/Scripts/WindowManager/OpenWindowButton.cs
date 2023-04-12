using UnityEngine;
using UnityEngine.UI;
using System;

public class OpenWindowButton : MonoBehaviour 
{
	[SerializeField] private Window _windowOpen;
	private UnityEngine.UI.Button _button;
	private void Awake()
	{
		_button = GetComponent<UnityEngine.UI.Button>();
		
		_button.onClick.AddListener(() =>
		{
			WindowManager.Instance.HandleCurrentActiveWindow(_windowOpen);
		});
	}
}
