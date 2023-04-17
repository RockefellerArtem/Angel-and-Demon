using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpHeight;
    [SerializeField] private float _timeReloadJump;

    [SerializeField] private bool _isGrounded;
    [SerializeField] private Transform _groundCheck;

    [SerializeField] private Rigidbody2D _player;

    [SerializeField] private GameObject _demon;
    [SerializeField] private GameObject _angel;

    [SerializeField] private SpriteRenderer _currentSprite;

    [SerializeField] private TeleportController _teleportController;
    
    private float _timeJump;

    private void OnEnable()
    {
        _teleportController.OnChangeImagePlayer += ChangeImage;
    }

    private void Start()
    {
        _demon.SetActive(true);
        _angel.SetActive(false);
    }

    private void Update()
    {
        if (_timeJump + _timeReloadJump < Time.time)
        {
            var colliders = Physics2D.OverlapCircleAll(_groundCheck.position, 0.04f);
            
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject.layer == 6)
                {
                    _isGrounded = true;
                }
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            var vectorSpeed = _player.velocity;
            
            vectorSpeed.x = _speed;

            _player.velocity = vectorSpeed;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            var vectorSpeed = _player.velocity;
            
            vectorSpeed.x = -_speed;

            _player.velocity = vectorSpeed;
        }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
        {
            if (_isGrounded)
            {
                _timeJump = Time.time;
                _isGrounded = false;
                _player.AddForce(Vector2.up * _jumpHeight, ForceMode2D.Impulse);
            }
        }
    }
    
    private void ChangeImage()
    {
        _demon.SetActive(false);
        _angel.SetActive(true);
    }
}
