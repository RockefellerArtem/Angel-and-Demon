using System;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Scripts.Level
{
    public class LevelHandler : MonoBehaviour
    {
        [SerializeField] private int _indexLevel;

        public event Action<LevelHandler> OnExitLevel;

        private CanvasGroup _canvasGroup;
        public CanvasGroup CanvasGroup => _canvasGroup;
        public int IndexLevel => _indexLevel;

        private void Update()
        {
            //if (Input.GetKeyDown(KeyCode.Space))
            //{
            //    for (int i = 0; i < _points.Count - 2; i++)
            //    {
            //        _points[i].HandlerClickButton();
            //    }   
            //}
        }

        public void StartLevel()
        {

        }
        
        private void OnHandleClickPoint()
        {
            //AudioManager.Instance.PlaySound(SoundsType.Tab);
            
            //if (_counterHolder.Count >= 10)
            //{
            //    OnExitLevel?.Invoke(this);
            //}
        }
    }
}