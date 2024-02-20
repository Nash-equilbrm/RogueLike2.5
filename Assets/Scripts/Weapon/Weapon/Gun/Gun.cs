using MyGame.ObjectPool;
using System.Collections;
using System.Collections.Generic;
using System.Resources;
using System.Runtime.CompilerServices;
using Tools;
using UnityEngine;
using UnityEngine.Scripting;


namespace MyGame.Weapon
{
    public abstract class Gun : MonoBehaviour, IWeapon
    {
        [RequiredMember][SerializeField] protected Transform _firingTransform;
        [RequiredMember][SerializeField] protected GameObject _bulletPrefab;
        [SerializeField] protected int _totalBullet;
        [SerializeField] protected int _currentBullet;

        protected virtual void Start()
        {
            var bulletPool = BulletPool.Instance.CreatePool(_bulletPrefab.name, _bulletPrefab);
            if (_totalBullet < 0) _totalBullet = 0;
            bulletPool.Prepare(_totalBullet + 10);
        }

        protected virtual void Shoot(Vector3 position)
        {

        }

        public virtual bool CanAttack()
        {
            return false;
        }

        public virtual void Attack(Vector3 targetPos = default)
        {
        }

        public virtual void ResetWeapon()
        {
        }

        public virtual void OnReleased()
        {
        }
    }
}

