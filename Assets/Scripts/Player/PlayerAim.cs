using MyGame.ObjectPool;
using MyGame.Weapon;
using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;


namespace MyGame.PlayerControl
{
    public partial class Player
    {
        [Header("Weapon")]
        [SerializeField] private Gun _primaryWeapon;

        [Header("Player aim")]
        [SerializeField] private LayerMask _environmentLayerMask;
        [SerializeField] private float _maxRaycastDistance = 1000f;
        [SerializeField] private Transform _hitTransform;

        private Vector2 _playerAimPos = Vector2.zero;
        private Ray _ray;
        private RaycastHit _hit;
        

        private void OnPlayerAim(Vector2 screenPos)
        {
            _playerAimPos = screenPos;
            _ray = Camera.main.ScreenPointToRay(_playerAimPos);
            if (Physics.Raycast(_ray, out RaycastHit _hit, _maxRaycastDistance, _environmentLayerMask))
            {
                if (_hitTransform != null)
                {
                    _hitTransform.position = _hit.point;
                }
            }
        }


        private void UpdateWeapon()
        {
            if(PlayerUseWeapon.IsPressed())
            {
                _primaryWeapon.Attack(_hitTransform.position);
            }
            else if(PlayerUseWeapon.WasReleasedThisFrame())
            {
                _primaryWeapon.OnReleased();
            }
        }


    }
}

