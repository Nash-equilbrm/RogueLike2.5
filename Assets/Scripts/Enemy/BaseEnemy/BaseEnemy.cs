using MyGame.PlayerControl;
using System;
using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;


namespace MyGame.Enemy
{
    public abstract partial class BaseEnemy : MonoBehaviour
    {
        [SerializeField] private Player _target;
        public Player Target { get => _target; }

        private StateMachine<BaseEnemy> _stateMachine = new StateMachine<BaseEnemy>();
        private EnemyPatrolState _patrolState;
        private EnemyChasePlayerState _chasePlayerState;
        private EnemyAttackState _attackState;
        private EnemyDieState _dieState;


        private void Awake()
        {
            GetPlayer();
            InitStateMachine();
            InitHealth();
        }


        void Update()
        {
            _stateMachine.CurrentState.LogicUpdate();
        }

        internal virtual void ResetEnemy()
        {
        }

        private void GetPlayer()
        {
            if (Target == null)
            {
                _target = FindObjectOfType<Player>();
            }
        }

        #region State management
        private void InitStateMachine()
        {
            _patrolState = new EnemyPatrolState(this);
            _chasePlayerState = new EnemyChasePlayerState(this);
            _attackState = new EnemyAttackState(this);
            _dieState = new EnemyDieState(this);

            _stateMachine.Initialize(_patrolState);
        }

        internal void ChangeState(EnemyState enemyState)
        {
            switch (enemyState)
            {
                case EnemyState.Patrol:
                    {
                        _stateMachine.ChangeState(_patrolState);
                        break;
                    }
                case EnemyState.ChasePlayer:
                    {
                        _stateMachine.ChangeState(_chasePlayerState);
                        break;
                    }
                case EnemyState.Attack:
                    {
                        _stateMachine.ChangeState(_attackState);
                        break;
                    }
                case EnemyState.Die:
                    {
                        _stateMachine.ChangeState(_dieState);
                        break;
                    }
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
            return _currentHp <= 0f;
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
        
        #endregion


       

    }
}
