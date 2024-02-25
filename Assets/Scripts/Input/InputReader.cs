using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


namespace MyGame.Input
{
    [CreateAssetMenu(menuName = "Scriptable Object/Input Reader", fileName = "New Input Reader")]
    public class InputReader : ScriptableObject, GameInputActions.IPlayerActions
    {
        private GameInputActions _inputActions;

        #region Player Input Actions
        public InputAction PlayerMovement { get => _inputActions.Player.PlayerMovement; }
        public InputAction PlayerAim { get => _inputActions.Player.PlayerAim; }
        public InputAction PlayerUseWeapon { get => _inputActions.Player.PlayerUseWeapon; }
        public InputAction PlayerDash { get => _inputActions.Player.PlayerDash; }


        public Action<InputAction.CallbackContext> _onPlayerAimCallback;
        public Action<InputAction.CallbackContext> _onPlayerDashCallback;
        public Action<InputAction.CallbackContext> _onPlayerMovementCallback;
        public Action<InputAction.CallbackContext> _onPlayerUseWeaponCallback;
        #endregion

        private void OnEnable()
        {
            if(_inputActions == null)
            {
                _inputActions = new GameInputActions();
            }

            _inputActions.Player.Enable();
            _inputActions.Player.SetCallbacks(this);
        }

        private void OnDisable()
        {
            _inputActions.Player.Disable();
            _inputActions.Player.RemoveCallbacks(this);
        }

        public void OnPlayerAim(InputAction.CallbackContext context)
        {
            _onPlayerAimCallback?.Invoke(context);
        }

        public void OnPlayerDash(InputAction.CallbackContext context)
        {
            Debug.Log("OnPlayerDash");
            if(context.phase == InputActionPhase.Started)
            {
                _onPlayerDashCallback?.Invoke(context);
            }
        }

        public void OnPlayerMovement(InputAction.CallbackContext context)
        {
            _onPlayerMovementCallback?.Invoke(context);
        }

        public void OnPlayerUseWeapon(InputAction.CallbackContext context)
        {
            _onPlayerUseWeaponCallback?.Invoke(context);
        }
    }
}

