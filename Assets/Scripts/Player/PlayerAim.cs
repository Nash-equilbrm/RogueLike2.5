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
        [SerializeField] private Transform _primaryWeaponHolder;
        [SerializeField] private Gun _primaryWeapon;
        public bool IsUpdateWeapon { get; set; } = true;
        [Header("Player aim")]
        [SerializeField] private LayerMask _environmentLayerMask;
        [SerializeField] private float _maxRaycastDistance = 99999f;
        [SerializeField] private Transform _hitTransform;

        public Vector3 AimDirection => (Vector3.Scale((_hitTransform.position - transform.position), new Vector3(1f, 0f, 1f))).normalized;

        private Vector2 _playerAimPos = Vector2.zero;
        private Ray _ray;
        private RaycastHit _hit;
        

       private void OnWeaponEnable()
        {
            if (_primaryWeapon == null)
            {
                _primaryWeapon = _primaryWeaponHolder.GetChild(0).GetComponent<Gun>();
            }
        }

        private void UpdatePlayerAim()
        {
            if (IsUpdateWeapon)
            {
                _playerAimPos = PlayerAim.ReadValue<Vector2>();
                _ray = Camera.main.ScreenPointToRay(_playerAimPos);
                if (Physics.Raycast(_ray, out RaycastHit _hit, _maxRaycastDistance, _environmentLayerMask))
                {
                    if (_hitTransform != null)
                    {
                        _hitTransform.position = _hit.point;
                    }
                }
            }
        }


        private void UpdateWeapon()
        {
            if (IsUpdateWeapon)
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
}

