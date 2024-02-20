using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MyGame.PlayerControl
{
    public partial class Player
    {
        [Header("Player Animation")]
        [SerializeField] private Transform _character;
        [SerializeField] private Animator _animator;
        [SerializeField] private Transform _hand1;
        [SerializeField] private Transform _hand2;
        private bool _runAnim = false;
        private int _animDirection = 1; // look at right side
        private void UpdateAnimation()
        {
            if( _animator != null)
            {
                _animator.SetBool("IsRunning", _runAnim);
            }
            UpdatePlayerHand(_hand1);
            UpdatePlayerHand(_hand2);

        }


        private void UpdatePlayerHand(Transform hand)
        {
            Vector2 playerScreenPos = Camera.main.WorldToScreenPoint(_hand1.position);
            Vector2 playerToAimVector = _playerAimPos - playerScreenPos;
            float handEulerZ = Mathf.Atan2(playerToAimVector.y, playerToAimVector.x) * Mathf.Rad2Deg;
            Vector3 handEulers = hand.transform.eulerAngles;
            if (handEulerZ > 90f || handEulerZ < -90f)
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
                hand.transform.eulerAngles = new Vector3(handEulers.x, handEulers.y, handEulerZ - 180);
            }
            else {
                transform.localScale = Vector3.one;
                hand.transform.eulerAngles = new Vector3(handEulers.x, handEulers.y, handEulerZ);
            }
        }
    }
}

