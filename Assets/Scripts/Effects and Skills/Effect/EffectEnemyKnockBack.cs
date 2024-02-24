using MyGame.Enemy;
using MyGame.PlayerControl;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

        protected override void ApplyEffectOnce(object target)
        {
            if (target != null)
            {
                BaseEnemy e = (BaseEnemy)target;
                _amount = KnockBackAmount;
                e.CurrentVelocity = Direction * Amount * Time.deltaTime;
            }
        }

        protected override void OnBeginApplyEffect(object target)
        {
            base.OnBeginApplyEffect(target);
        }

        protected override void OnEndApplyEffect(object target)
        {
            base.OnEndApplyEffect(target);
            if (target != null)
            {
                BaseEnemy e = (BaseEnemy)target;
                e.CurrentVelocity = Vector3.zero;
            }
            IsDone = true;
        }
    }
}

