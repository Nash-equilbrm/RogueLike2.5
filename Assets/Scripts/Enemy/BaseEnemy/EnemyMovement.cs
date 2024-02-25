using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MyGame.Enemy
{
    public class EnemyMovement: MonoBehaviour
    {
        [Header("Movement")]
        public bool updateMovement = true;
        [SerializeField] private CharacterController _movementController;
        private Vector3 _currentVelocity;
        public Vector3 CurrentVelocity { get => _currentVelocity; set => _currentVelocity = value; }

        private void Update()
        {
            if (updateMovement && _movementController != null)
            {
                _movementController.Move(_currentVelocity);
                _movementController.Move(-Physics.gravity.y * Vector3.down * Time.deltaTime);
            }
        }
    }
}
