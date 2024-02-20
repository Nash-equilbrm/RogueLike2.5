using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MyGame.Enemy
{
    public abstract partial class BaseEnemy
    {
        [Header("Health")]
        [SerializeField] private float _totalHp;
        [SerializeField] private float _currentHp;


        private void InitHealth()
        {
            _totalHp = 100f;
            _currentHp = _totalHp;
        }


        public virtual void TakeDamage(float damage)
        {
            _currentHp -= damage;
        }
    }
}

