using MyGame.Effects;
using MyGame.PlayerControl;
using System;
using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;


namespace MyGame.Enemy
{
    public abstract class BaseEnemy : MonoBehaviour
    {
        [SerializeField] private EnemyFlowControl _flowControl;
        [SerializeField] private EnemyHealth _health;
        [SerializeField] private EnemyEffectManager _effectManager;
        [SerializeField] private EnemyMovement _movement;

        private Player _target;
       

        public Player Target { get => _target; }
        public EnemyFlowControl FlowControl { get => _flowControl; }
        public EnemyHealth Health { get => _health; }
        public EnemyEffectManager EffectManager { get => _effectManager; }
        public EnemyMovement Movement { get => _movement; }

        private void Awake()
        {
            GetPlayer();
        }

        private void Start()
        {
            if (EnemyManager.HasInstance)
            {
                EnemyManager.Instance.Enemies.Add(this);
            }
        }

        private void GetPlayer()
        {
            if (Target == null)
            {
                _target = FindObjectOfType<Player>();
            }
        }

       

        #region Attack State
        internal virtual void OnAttackUpdate()
        {
        }

        internal virtual void OnAttackStart()
        {
        }

        internal virtual void OnAttackEnd()
        {
        }
        #endregion


        #region Chasing Player State
        internal virtual void OnChasingPlayerUpdate(Player p)
        {
        }

        internal virtual void OnChasingPlayerStart()
        {
        }

        internal virtual void OnChasingPlayerEnd()
        {
        }

        internal virtual bool ReachPlayer(Player p)
        {
            return false;
        }
        #endregion


        #region Die State
        internal virtual void OnDeadUpdate()
        {
        }

        internal virtual void OnDeadStart()
        {
        }

        internal virtual void OnDeadEnd()
        {
            gameObject.SetActive(false);
        }

        internal virtual bool IsDead()
        {
            return _health.CurrentHp <= 0f;
        }
        #endregion


        #region Patrol State
        internal virtual void OnPatrolUpdate()
        {
        }


        internal virtual void OnPatrolStart()
        {
        }

        internal virtual void OnPatrolEnd()
        {
        }

        internal virtual bool FindPlayer(Player p)
        {
            return false;
        }
        #endregion
        


       

    }
}
