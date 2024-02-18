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

        private void Awake()
        {
            _gameInputActions = new GameInputActions();
        }

        private void OnEnable()
        {
            EnablePlayerInput();
        }

        private void OnDisable()
        {
            DisablePlayerInput();
        }

        #region Input
        private void EnablePlayerInput()
        {
            _gameInputActions.Player.Enable();

            // movement
            PlayerMovement.performed += Movement_performed;
            PlayerMovement.canceled += Movement_canceled;

            // aim
            PlayerAim.performed += Aim_performed;

        }


        private void Movement_canceled(InputAction.CallbackContext context)
        {
            OnPlayerMove(Vector2.zero);
        }

        private void Movement_performed(InputAction.CallbackContext context)
        {
            Vector2 input = context.ReadValue<Vector2>();
            OnPlayerMove(input);
        }

        private void Aim_performed(InputAction.CallbackContext context)
        {
            OnPlayerAim(context.ReadValue<Vector2>());
        }


        private void DisablePlayerInput()
        {
            _gameInputActions.Player.Disable();

            // movement
            PlayerMovement.performed -= Movement_performed;
            PlayerMovement.canceled -= Movement_canceled;

            // aim
            PlayerAim.performed -= Aim_performed;

        }
        #endregion



        private void Update()
        {
            UpdateMovement();
            UpdateWeapon();
            UpdateAnimation();
        }
    }
}

