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
        if (isState)
        {
            _animatorDoor.ResetTrigger("Down");
            _animatorDoor.SetTrigger("Up");
            
            _animatorPlatform.ResetTrigger("Up");
            _animatorPlatform.SetTrigger("Lower");
        }
        else
        {
            _animatorDoor.ResetTrigger("Up");
            _animatorDoor.SetTrigger("Down");
            
            _animatorPlatform.ResetTrigger("Lower");
            _animatorPlatform.SetTrigger("Up");
            
        }
    }
}
