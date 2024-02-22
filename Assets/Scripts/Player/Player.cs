using MyGame.Input;
using MyGame.ObjectPool;
using System;
using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;
using UnityEngine.InputSystem;


namespace MyGame.PlayerControl
{
    public partial class Player : MonoBehaviour
    {
        private GameInputActions _gameInputActions;
        private InputAction PlayerMovement { get => _gameInputActions.Player.PlayerMovement; }
        private InputAction PlayerAim { get => _gameInputActions.Player.PlayerAim; }
        private InputAction PlayerUseWeapon { get => _gameInputActions.Player.PlayerUseWeapon; }
        private InputAction PlayerDash { get => _gameInputActions.Player.PlayerDash; }

        private void Awake()
        {
            _gameInputActions = new GameInputActions();
            InitHealth();
        }

        private void OnEnable()
        {
            EnablePlayerInput();
            OnMovementEnable();
            OnHealthEnable();
        }

        private void OnDisable()
        {
            DisablePlayerInput();
            OnMovementDisable();
            OnHealthDisable();
        }

        #region Input
        private void EnablePlayerInput()
        {
            _gameInputActions.Player.Enable();

            // movement
            PlayerDash.performed += Dash_performed;

        }



        private void Dash_performed(InputAction.CallbackContext context)
        {
            OnPlayerDash();
        }



        private void DisablePlayerInput()
        {
            _gameInputActions.Player.Disable();

            // movement
            PlayerDash.performed -= Dash_performed;

        }
        #endregion



        private void Update()
        {
            UpdateMovement();
            UpdatePlayerAim();
            UpdateWeapon();
            UpdateAnimation();
            UpdatePlayerHandRotation();
        }

        private void FixedUpdate()
        {
        }
    }
}

