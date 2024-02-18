using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGame.PlayerControl
{
    // Only for player movement
    public partial class Player : MonoBehaviour
    {
        [Header("Player Movement")]
        [SerializeField] private float _moveSpeed = 1f;


        private Vector3 _currentVelocity = Vector3.zero;

        private void OnPlayerMove(Vector2 inputVector)
        {
            Vector3 inputVector3 = new Vector3(inputVector.x, 0f, inputVector.y);
            _currentVelocity = inputVector3.normalized * _moveSpeed * Time.deltaTime;
            
            _runAnim = (inputVector3 != Vector3.zero) ? true : false;
            if (inputVector.x > 0f) _animDirection = 1;
            else if (inputVector.x < 0f) _animDirection = -1;
        }


        private void UpdateMovement()
        {
            //transform.position += _currentVelocity;
            transform.Translate(_currentVelocity);
        }
    }
}
