using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MyGame.Weapon
{
    public abstract class Bullet: MonoBehaviour
    {
        [SerializeField] private Collider _collider;
        [SerializeField] private LayerMask _enemyLayerMask;
        protected BulletTrajectory _trajectory;
        [SerializeField] protected float _bulletSpeed;
        [SerializeField] private float _existTime = 3f;
        private float _existTimer = 0f;
        private Vector3 _targetPosition;


        public float BulletSpeed { get => _bulletSpeed; set => _bulletSpeed = value; }
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
            _existTimer = 0;
            transform.localPosition = Vector3.zero;
        }

        public virtual void Update()
        {
            if(_isMoving)
            {
                _trajectory?.MoveBullet(this);
            }
            if(_existTimer >= _existTime)
            {
                gameObject.SetActive(false);
            }
            else
            {
                _existTimer += Time.deltaTime;
            }
        }

        protected virtual void OnTriggerEnter(Collider other)
        {
            gameObject.SetActive(false);
            Debug.Log(other.name);
            if ((_enemyLayerMask.value & (1 << other.gameObject.layer)) > 0)
            {
                Debug.Log("Hit enemy");
            }
            
        }

        private void OnDisable()
        {
            ResetBullet();
        }

    }
}

