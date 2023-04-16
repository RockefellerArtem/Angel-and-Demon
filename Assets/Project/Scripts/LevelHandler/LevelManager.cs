using System;
using System.Collections.Generic;
using Project.Scripts.Level;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class LevelManager : SingletonMono<LevelManager>
{
    [FormerlySerializedAs("_startLevelButtons")] [SerializeField] private List<StartLevelButton> _levelButtons;
    [SerializeField] private List<LevelHandler> _levelHandlers;

    //[SerializeField] private TMP_Text _counerLevelText;

    //[SerializeField] private GameObject _popupMessage;

    private LevelHandler _currentLevelHandler;

    private bool _isActive = false;

    public  void Start()
    {
        for (int i = 0; i < _levelButtons.Count; i++)
        {
            _levelButtons[i].Init();
            _levelButtons[i].OnClickLevelButton += OnHandleClickLevelButton;
        }

        OnEnableLevelAD();
    }

    private void OnEnableLevelAD()
    {
        var adsLevelButtons = new List<StartLevelButton>();
        var isCompletAllLevels = true;
        
        for (int i = 0; i < _levelButtons.Count; i++)
        {
            //if (_levelButtons[i].IsAdLevel)
            //{
            //    adsLevelButtons.Add(_levelButtons[i]);
            //    continue;
            //}

            if (_levelButtons[i].IsComplet() == false)
            {
                isCompletAllLevels = false;
            }
        }

        if (isCompletAllLevels == false)
        {
            for (int i = 0; i < adsLevelButtons.Count; i++)
            {
                adsLevelButtons[i].SetInteractableButton(false);
            }
            
            return;
        }

        OnEnablePopup();
    }

    private void OnEnablePopup()
    {
        if (_isActive) return;

        //_popupMessage.SetActive(true);
        _isActive = true;
    }

    private void OnHandleClickLevelButton(int indexLevel)
    {
        for (int i = 0; i < _levelHandlers.Count; i++)
        {
            if (_levelHandlers[i].IndexLevel == indexLevel)
            {
                _currentLevelHandler = _levelHandlers[i];
                _levelHandlers[i].OnExitLevel += OnHandleExitLevel;
                
                _levelHandlers[i].gameObject.SetActive(true);
                _levelHandlers[i].StartLevel();
               
                //_counerLevelText.text = $"Уровень {_levelHandlers[i].IndexLevel.ToString()}";
            }
        }
        
        WindowManager.Instance.HandleCurrentActiveWindow(Window.Game);
    }

    public void OnHandleExitLevel(LevelHandler levelHandler)
    {
        WindowManager.Instance.HandleCurrentActiveWindow(Window.Menu);
        _currentLevelHandler = null;
        
        levelHandler.OnExitLevel -= OnHandleExitLevel;
        levelHandler.gameObject.SetActive(false);

        for (int i = 0; i < _levelButtons.Count; i++)
        {
            if (_levelButtons[i].IndexLevel == levelHandler.IndexLevel && _levelButtons[i].IsComplet() == false) break;

            if (_levelButtons[i].IndexLevel != levelHandler.IndexLevel + 1) continue;
            //if(_levelButtons[i].IsAdLevel) continue;
            
            _levelButtons[i].UnLockLevel();
            break;
        }

        OnEnableLevelAD();
    }

    public void ExitLevelToMenu()
    {
        OnHandleExitLevel(_currentLevelHandler);
    }
}
