using MyGame.Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


namespace MyGame.PlayerControl
{
    public partial class Player
    {
        [Header("Player Health")]
        [SerializeField] private float _totalHp;
        [SerializeField] private float _currentHp;
        [SerializeField] private float _knockbackForce = 5f;

        private void InitHealth()
        {
            _totalHp = 100f;
            _currentHp = _totalHp;

        }

        private void OnHealthEnable()
        {
            this.Register(EventID.PlayerTakeDamageFromEnemy, OnHurtByEnemy);
        }

        private void OnHealthDisable()
        {
            this.Unregister(EventID.PlayerTakeDamageFromEnemy, OnHurtByEnemy);
        }

        private void TakeDamage(float damage)
        {
            _currentHp -= damage;
        }

        private void OnHurtByEnemy(object data)
        {
            BaseEnemy enemy = (BaseEnemy)data;
            TakeDamage(1);
            // knock back effect
            Vector3 knockbackDirection = (transform.position - enemy.transform.position).normalized;
            
        }
    }

}
