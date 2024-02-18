using MyGame.PlayerControl;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGame.CameraControl
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform _targetTransform;
        [SerializeField] private Vector3 _offset;
        [SerializeField] private float _cameraMoveSpeed;

        void Start()
        {
            if( _targetTransform == null)
            {
                _targetTransform = FindObjectOfType<Player>().transform;
            }
        }

        private void LateUpdate()
        {
            FollowTarget(_offset);
        }

        private void FollowTarget(Vector3 offset)
        {
            transform.position = Vector3.Lerp(transform.position, _targetTransform.position + offset, _cameraMoveSpeed * Time.deltaTime);
        }
    }
}

