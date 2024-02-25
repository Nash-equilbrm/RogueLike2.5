using MyGame.Input;
using MyGame.Skill;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

namespace MyGame.PlayerControl
{
    // Only for player movement
    public class PlayerMovement: MonoBehaviour
    {
        [SerializeField] private Player _player;
        [Header("Player Movement")]
        [SerializeField] private PlayerAim _playerAim;
        [SerializeField] private CharacterController _movementController;
        [SerializeField] private float _moveSpeed = 1f;
        [SerializeField] private float _dashSpeed = 30f;
        [SerializeField] private SkillDash _skillDash = null;


        private Vector3 _currentVelocity = Vector3.zero;
        public Vector3 CurrentVelocity { get => _currentVelocity; set => _currentVelocity = value; }



        private void GetMovementInput(Vector2 inputVector)
        {
            if(_skillDash.IsApplying)
            {
                return;
            }
            Vector3 inputVector3 = new Vector3(inputVector.x, 0f, inputVector.y);
            _currentVelocity = inputVector3.normalized * _moveSpeed * Time.deltaTime;

        }

        private void OnEnable()
        {
            if (_skillDash == null)
            {
                _skillDash = new SkillDash();
            }
            _skillDash.SetParams(duration: .1f, amount: _dashSpeed, coolDown: 1f);

            _player.InputReader._onPlayerDashCallback += OnPlayerDash;
        }


        private void OnDisable()
        {
            _player.InputReader._onPlayerDashCallback -= OnPlayerDash;
        }

        private void Update()
        {
            if (_movementController != null)
            {
                GetMovementInput(_player.InputReader.PlayerMovement.ReadValue<Vector2>());
                // movement by input
                _movementController.Move(_currentVelocity);
                // apply gravity
                _movementController.Move(-Physics.gravity.y * Vector3.down * Time.deltaTime);
            }
        }


        private void OnPlayerDash(InputAction.CallbackContext context)
        {
            Debug.Log("ApplySkill");
            if (_currentVelocity != Vector3.zero)
            {
                _skillDash.Direction = _currentVelocity.normalized;
            }
            else
            {
                _skillDash.Direction = _playerAim.AimDirection;
            }
            _skillDash.ApplySkill(this);
        }


    }
}
