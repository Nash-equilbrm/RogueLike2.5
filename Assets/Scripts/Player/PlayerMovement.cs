using MyGame.Skill;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

namespace MyGame.PlayerControl
{
    // Only for player movement
    public partial class Player
    {
        [Header("Player Movement")]
        [SerializeField] private CharacterController _movementController;
        [SerializeField] private float _moveSpeed = 1f;
        [SerializeField] private float _dashSpeed = 30f;

        private SkillDash _skillDash;

        private Vector3 _currentVelocity = Vector3.zero;
        public Vector3 CurrentVelocity { get => _currentVelocity; set => _currentVelocity = value; }

        public bool IsUpdateMovement { get; set; } = true;


        private void GetMovementInput(Vector2 inputVector)
        {
            if(_skillDash.IsApplying)
            {
                return;
            }
            Vector3 inputVector3 = new Vector3(inputVector.x, 0f, inputVector.y);
            _currentVelocity = inputVector3.normalized * _moveSpeed * Time.deltaTime;


            // update orientation for anim
            _runAnim = (inputVector3 != Vector3.zero) ? true : false;
            if (inputVector.x > 0f) _animDirection = 1;
            else if (inputVector.x < 0f) _animDirection = -1;
        }

        private void OnMovementEnable()
        {
            if (_skillDash == null) _skillDash = new SkillDash(duration: .1f, dashSpeed: _dashSpeed, coolDown: 1f);
        }

        private void OnMovementDisable()
        {

        }

        private void UpdateMovement()
        {
            if (IsUpdateMovement && _movementController != null)
            {
                GetMovementInput(PlayerMovement.ReadValue<Vector2>());
                // movement by input
                _movementController.Move(_currentVelocity);
                // apply gravity
                _movementController.Move(-Physics.gravity.y * Vector3.down * Time.deltaTime);
            }
        }


        private void OnPlayerDash()
        {
            if(_currentVelocity != Vector3.zero)
            {
                _skillDash.Direction = _currentVelocity.normalized;
            }
            else
            {
                _skillDash.Direction = AimDirection;
            }
            _skillDash.DashSpeed = _dashSpeed;
            _skillDash.ApplySkill(this);
        }


    }
}
