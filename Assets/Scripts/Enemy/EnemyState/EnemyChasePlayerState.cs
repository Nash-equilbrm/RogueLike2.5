using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;


namespace MyGame.Enemy
{
    public class EnemyChasePlayerState : State<BaseEnemy>
    {
        public EnemyChasePlayerState(BaseEnemy context) : base(context)
        {
        }

        public override void Enter()
        {
            _context.OnChasingPlayerStart();
        }

        public override void Exit()
        {
            _context.OnChasingPlayerEnd();
        }

        public override void LogicUpdate()
        {
            if (_context.IsDead())
            {
                _context.FlowControl.ChangeState(EnemyState.Die);
            }

            if (_context.FindPlayer(_context.Target))
            {
                _context.OnChasingPlayerUpdate(_context.Target);
                if( _context.ReachPlayer(_context.Target) )
                {
                    _context.FlowControl.ChangeState(EnemyState.Attack);
                }
            }
            else
            {
                _context.FlowControl.ChangeState(EnemyState.Patrol);
            }
        }
    }
}
