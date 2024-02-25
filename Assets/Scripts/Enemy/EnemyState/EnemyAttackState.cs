using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;


namespace MyGame.Enemy
{
    public class EnemyAttackState : State<BaseEnemy>
    {
        public EnemyAttackState(BaseEnemy context) : base(context)
        {
        }

        public override void Enter()
        {
            _context.OnAttackStart();
        }

        public override void Exit()
        {
            _context.OnAttackEnd();
        }

        public override void LogicUpdate()
        {
            if (_context.IsDead())
            {
                _context.FlowControl.ChangeState(EnemyState.Die);
            }

            _context.OnAttackUpdate();

            if (!_context.ReachPlayer(_context.Target))
            {
                _context.FlowControl.ChangeState(EnemyState.ChasePlayer);
            }
            else if (!_context.FindPlayer(_context.Target))
            {
                _context.FlowControl.ChangeState(EnemyState.Patrol);

            }
        }
    }
}

