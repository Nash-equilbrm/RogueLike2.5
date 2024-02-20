using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;


namespace MyGame.Enemy
{
    public class EnemyDieState : State<BaseEnemy>
    {
        public EnemyDieState(BaseEnemy context) : base(context)
        {
        }

        public override void Enter()
        {
            _context.OnDeadStart();
        }


        public override void Exit()
        {
            _context.OnDeadEnd();
        }

        public override void LogicUpdate()
        {
            _context.OnDeadUpdate();
        }
    }
}
