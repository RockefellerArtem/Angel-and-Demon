using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StartLevelButton : MonoBehaviour
{
    #region Refs

    [SerializeField] private int _indexLevel;
    [SerializeField] private Image _fader;
    [SerializeField] private Image _icon;
    
    [SerializeField] private Sprite _playIcon;
    [SerializeField] private Sprite _lockIcon;
    
    [SerializeField] private UnityEngine.UI.Button _button;
    [SerializeField] private bool _isLock = false;

    //[SerializeField] private TMP_Text _counterText;
    [SerializeField] private TMP_Text _counterCellLevelText;

    //[SerializeField] private bool _isAdLevel = false;
    public event Action<int> OnClickLevelButton;

    private CanvasGroup _canvasGroup;
    public CanvasGroup CanvasGroup => _canvasGroup;
    public int IndexLevel => _indexLevel;
    
    //public bool IsAdLevel => _isAdLevel;

    public bool IsLock => _isLock;

    #endregion

    #region Unity API

    private void Awake()
    {
        TryGetComponent(out _canvasGroup);
    }
    public void Init()
    {
        _icon.sprite = _lockIcon;
        _counterCellLevelText.text = _indexLevel.ToString();

        if (_isLock)
        {
            _isLock = Convert.ToBoolean(PlayerPrefs.GetInt($"levelButton_{_indexLevel}", 1));
        }
       
        if (_isLock == false) UnLockLevel();
        else LockLevel();

        UpdateText();
        
        _button.onClick.AddListener(HandlerClickButton);
    }

    public void SetInteractableButton(bool interactable)
    {
        _button.interactable = interactable;
    }

    public bool IsComplet()
    {
        return PlayerPrefs.GetInt($"LevelCounter_{_indexLevel}") >= 10;
    }
    private void OnEnable()
    {
        UpdateText();
    }

    #endregion

    #region Private API
    
    private void UpdateText()
    {
        var count = PlayerPrefs.GetInt($"LevelCounter_{_indexLevel}");
        //_counterText.text = $"{count}/10";
        //
        //if (count >= 1 )
        //{
        //    _counterText.text = $"<color=yellow>{count}</color>/<color=white>10</color>";
        //}
        //
        //if (count == 10) 
        //{
        //    _counterText.text = $"<color=green>{count}</color>/<color=green>{count}</color>";
        //}
        
    }
    
    public void UnLockLevel()
    {
        PlayerPrefs.SetInt($"levelButton_{_indexLevel}", 0);
        _icon.sprite = _playIcon;
        _fader.gameObject.SetActive(false);
        _isLock = false;
    }

    private void LockLevel()
    {
        _icon.sprite = _lockIcon;
       _fader.gameObject.SetActive(true);
    }
    private void HandlerClickButton()
    {
//#if UNITY_EDITOR
//        AdsController.Instance.ShowReward(() =>
//        {
//            UnLockLevel();
//        });
//        
//        AdsController.Instance.ShowInterstitial();
//#endif
        
        OnClickLevelButton?.Invoke(_indexLevel);

        
        
        
        
        
//        if (_isLock)
//        {
//            if (_isAdLevel)
//            {
//#if UNITY_EDITOR
//                UnLockLevel();
//#else 
//                AdsController.Instance.ShowReward(() =>
//                {
//                    UnLockLevel();
//                });
//#endif
//            }
//        }
        //AdsController.Instance.ShowInterstitial();
    }

    #endregion
}
