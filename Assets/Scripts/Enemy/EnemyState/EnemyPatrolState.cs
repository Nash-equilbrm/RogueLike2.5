using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;


namespace MyGame.Enemy
{
    public class EnemyPatrolState : State<BaseEnemy>
    {
        public EnemyPatrolState(BaseEnemy context) : base(context)
        {
        }

        public override void Enter()
        {
            _context.OnPatrolStart();
        }

        public override void Exit()
        {
            _context.OnPatrolEnd();
        }

        public override void LogicUpdate()
        {
            if (_context.IsDead())
            {
                _context.FlowControl.ChangeState(EnemyState.Die);
            }

            _context.OnPatrolUpdate();
            if (_context.FindPlayer(_context.Target))
            {
                _context.FlowControl.ChangeState(EnemyState.ChasePlayer);
            }
        }
    }
}

