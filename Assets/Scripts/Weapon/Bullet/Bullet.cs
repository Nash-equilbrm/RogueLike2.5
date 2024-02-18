using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MyGame.Weapon
{
    public abstract class Bullet: MonoBehaviour
    {
        [SerializeField] private Collider _collider;
        protected BulletTrajectory _trajectory;
        [SerializeField] protected float _bulletSpeed;
        public float BulletSpeed { get => _bulletSpeed; }

        private Vector3 _targetPosition;
        public Vector3 TargetPosition { 
            get => _targetPosition; 
            set {
                if(!_isMoving)
                    _targetPosition = value; 
            }
        }


        private bool _isMoving = false;

        public virtual void Initialize(BulletTrajectory trajectory)
        {
            _trajectory = trajectory;
        }
        
        public virtual void Shoot(Vector3 targetPos)
        {
            _targetPosition = targetPos;
            _isMoving = true;
        }

        public virtual void ResetBullet()
        {
            _targetPosition = Vector3.zero;
            _trajectory?.ResetTrajectory();
        }

        public virtual void Update()
        {
            if(_isMoving)
            {
                _trajectory?.MoveBullet(this);
            }
        }

        protected virtual void OnTriggerEnter(Collider other)
        {
            gameObject.SetActive(false);
            if (other.CompareTag("Player"))
            {
                Physics.IgnoreCollision(_collider, other);
            }
        }

        private void OnDisable()
        {
            ResetBullet();
        }

    }
}

