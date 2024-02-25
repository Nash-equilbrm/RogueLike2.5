using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;


namespace MyGame.Enemy
{
    public class EnemyFlowControl : MonoBehaviour
    {
        [SerializeField] private BaseEnemy _enemy;
        private StateMachine<BaseEnemy> _stateMachine = new StateMachine<BaseEnemy>();
        private EnemyPatrolState _patrolState;
        private EnemyChasePlayerState _chasePlayerState;
        private EnemyAttackState _attackState;
        private EnemyDieState _dieState;

        private void Awake()
        {
            InitStateMachine();
        }

        private void Update()
        {
            _stateMachine.CurrentState.LogicUpdate();
        }

        private void InitStateMachine()
        {
            _patrolState = new EnemyPatrolState(_enemy);
            _chasePlayerState = new EnemyChasePlayerState(_enemy);
            _attackState = new EnemyAttackState(_enemy);
            _dieState = new EnemyDieState(_enemy);

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
    }
}

