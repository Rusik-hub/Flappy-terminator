using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(PlayerShooter))]
[RequireComponent(typeof(Animator))]

public class PlayerInput : MonoBehaviour
{
    private PlayerMover _playerMover;
    private PlayerShooter _playerShooter;
    private Animator _animator;
    private bool _isShootReady = true;

    public void SetShootReady()
    {
        _isShootReady = true;
    }

    private void Start()
    {
        _playerMover = GetComponent<PlayerMover>();
        _playerShooter = GetComponent<PlayerShooter>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _playerMover.MoveUp();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            _playerMover.MoveDown();
        }
        if (Input.GetKeyDown(KeyCode.Space) && _isShootReady)
        {
            _isShootReady = false;

            _animator.SetTrigger("attack");
        }
    }
}
