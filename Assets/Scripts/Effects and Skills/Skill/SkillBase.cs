using MyGame.Effects;
using System.Collections;
using UnityEngine;

namespace MyGame.Skill
{
    [System.Serializable]
    public abstract class SkillBase : EffectBase
    {
        [SerializeField] protected float _coolDown;
        public float CoolDown { get => _coolDown; }
        protected float _coolDownTimer = 0f;
        public bool CoolingDown { get; protected set; }

        protected IEnumerator ApplySkillCoroutine(object target)
        {
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

        public void SetParams(float duration, float amount, float coolDown)
        {
            SetParams(duration, amount);
            _coolDown = coolDown;
        }
    }
}
