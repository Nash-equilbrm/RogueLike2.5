using MyGame.PlayerControl;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


namespace MyGame.Skill
{
    [System.Serializable]
    public class SkillDash : SkillBase
    {
        public Vector3 Direction { get; set; }
        public float DashSpeed {
            get
            {
                return _amount;
            }
            set {
                if(value < 0f) _amount = 0f;
                else _amount = value;
            }
        }
        public SkillDash()
        {
        }
        public SkillDash(float duration, float dashSpeed, float coolDown)
        {
            _duration = duration;
            _amount = dashSpeed;
            _coolDown = coolDown;
        }

        protected override void OnBeginApplyEffect(object target)
        {
            if (target != null)
            {
                Player p = (Player)target;
                _amount = DashSpeed;
                p.CurrentVelocity = Direction * Amount * Time.deltaTime;
            }
        }

        protected override void OnEndApplyEffect(object target)
        {
            if (target != null)
            {
                Player p = (Player)target;
                p.CurrentVelocity = Vector3.zero;
            }
        }

        protected override void OnBeginCoolDown(object target)
        {
        }

        protected override void OnEndCoolDown(object target)
        {
        }

        protected override void OnCoolDown(object target)
        {
        }
    }
}

