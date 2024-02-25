using MyGame.Enemy;
using System;
using UnityEngine;


namespace MyGame.Effects
{
    [Serializable]
    public class EffectEnemyKnockBack : EffectBase
    {
        public Vector3 Direction { get; set; }
        public float KnockBackAmount
        {
            get
            {
                return _amount;
            }
            set
            {
                if (value < 0f) _amount = 0f;
                else _amount = value;
            }
        }

        public EffectEnemyKnockBack()
        {
        }
        public EffectEnemyKnockBack(float duration, float knockBackAmount)
        {
            _duration = duration;
            _amount = knockBackAmount;
        }

        protected override void OnBeginApplyEffect(object target)
        {
            if (target != null)
            {
                BaseEnemy e = (BaseEnemy)target;
                e.FlowControl.enabled = false;
                _amount = KnockBackAmount;
                e.Movement.CurrentVelocity = Direction * Amount * Time.deltaTime;
            }
        }

        protected override void OnEndApplyEffect(object target)
        {
            if (target != null)
            {
                BaseEnemy e = (BaseEnemy)target;
                e.FlowControl.enabled = true;
                e.Movement.CurrentVelocity = Vector3.zero;
            }
            IsDone = true;
        }
    }
}

