using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEngine : MonoBehaviour
{
    [SerializeField] private PlatformState _platform;
    
    [SerializeField] private Animator _animatorDoor;
    [SerializeField] private Animator _animatorPlatform;

    private void OnEnable()
    {
        _platform.CallbackStatePlatform += InteractElementsMechanics;
    }

    private void InteractElementsMechanics(bool isState)
    {
        Debug.Log(isState);
        
        if (isState)
        {
            _animatorDoor.SetTrigger("Up");
            _animatorPlatform.ResetTrigger("Up");
            _animatorPlatform.SetTrigger("Lower");
        }
        else
        {
            _animatorDoor.SetTrigger("Down");
            _animatorPlatform.ResetTrigger("Up");
            _animatorDoor.SetTrigger("Up");
            _animatorPlatform.ResetTrigger("Lower");
            _animatorPlatform.SetTrigger("Up");
            
        }
    }
}
