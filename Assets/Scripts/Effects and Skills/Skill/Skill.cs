using MyGame.Effects;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGame.Skill
{
    public abstract class Skill : Effect
    {
        public float CoolDown { get; protected set; }
        protected float _coolDownTimer = 0f;
        public bool CoolingDown { get; protected set; }

        protected IEnumerator ApplySkillCoroutine(object target)
        {
            Debug.Log("ApplySkillCoroutine");
            yield return ApplyEffectCoroutine(target);

            // cool down
            CoolingDown = true;
            OnBeginCoolDown(target);

            while (_coolDownTimer <= CoolDown)
            {
                OnCoolDown(target);
                _coolDownTimer += Time.deltaTime;
                yield return null;
            }

            OnEndCoolDown(target);
            _coolDownTimer = 0f;
            CoolingDown = false;
        }


        protected virtual void OnCoolDown(object target)
        {

        }


        protected virtual void OnBeginCoolDown(object target)
        {

        }

        protected virtual void OnEndCoolDown(object target)
        {

        }

        public void ApplySkill(object target)
        {
            if (!CoolingDown)
            {
                (target as MonoBehaviour).StartCoroutine(ApplySkillCoroutine(target));
            }
        }
    }
}
