using MyGame.PlayerControl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MyGame.Skill
{
    public class SkillDash : Skill
    {
        public Vector3 Direction { get; set; }
        private float _dashSpeed = 0f;
        public float DashSpeed {
            get
            {
                return _dashSpeed;
            }
            set {
                if(value < 0f) _dashSpeed = 0f;
                else _dashSpeed = value;
            }
        }
        public SkillDash(float duration, float dashSpeed, float coolDown)
        {
            Duration = duration;
            DashSpeed = dashSpeed;
            CoolDown = coolDown;
        }

        protected override void OnBeginApplyEffect(object target)
        {
            if (target != null)
            {
                Player p = (Player)target;
                Amount = DashSpeed;
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

