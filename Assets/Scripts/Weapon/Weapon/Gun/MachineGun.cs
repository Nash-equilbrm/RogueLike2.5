using MyGame.ObjectPool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MyGame.Weapon
{
    public class MachineGun : Gun
    {
        [SerializeField] private float _reloadDuration = 2f;
        [SerializeField] private float _interval = 0.5f;
        private float _timer;
        private bool _isReloading;

        protected override void Start()
        {
            base.Start();
            _totalBullet = 20;
            _timer = _interval;
            _isReloading = false;
        }

        private void Update()
        {
            if (_currentBullet <= 0 && !_isReloading)
            {
                StartCoroutine(ResetWeaponCoroutine());
            }
        }

        protected override void Shoot(Vector3 position)
        {
            if (_timer >= _interval)
            {
                var bullet = BulletPool.Instance.GetPool(_bulletPrefab.name).Get(position: _firingTransform.position, rotation: Quaternion.identity);
                bullet.Shoot(position);
                _currentBullet--;
                _timer = 0;
            }
            else
            {
                _timer += Time.deltaTime;
            }
        }

        public override bool CanAttack()
        {
            return _currentBullet > 0;
        }

        public override void Attack(Vector3 targetPos = default)
        {
            if (CanAttack())
            {
                Shoot(targetPos);
            }
        }

        public override void ResetWeapon()
        {
            Debug.Log("Reset weapon");
            _currentBullet = _totalBullet;
        }

        private IEnumerator ResetWeaponCoroutine()
        {
            _isReloading = true;
            yield return new WaitForSeconds(_reloadDuration);
            ResetWeapon();
            _isReloading = false;
        }

        public override void OnReleased()
        {
            _timer = _interval;
        }
    }
}

