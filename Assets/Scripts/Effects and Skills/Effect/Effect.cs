using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MyGame.Effects
{
    public abstract class Effect 
    {
        public float Duration { get; protected set; }
        public float Amount { get; set; }
        protected float _timer = 0f;
        public bool IsApplying { get; private set; }


        protected IEnumerator ApplyEffectCoroutine(object target)
        {
            Debug.Log("ApplyEffectCoroutine");
            if (target == null)
            {
                yield break;
            }
            IsApplying = true;
            OnBeginApplyEffect(target);

            while(_timer <= Duration)
            {
                ApplyEffectOnce(target);
                _timer += Time.deltaTime;
                yield return null;
            }

            OnEndApplyEffect(target);
            _timer = 0f;
            IsApplying = false;
        }

        protected virtual void ApplyEffectOnce(object target)
        {

        }

        protected virtual void OnBeginApplyEffect(object target)
        {
        }

        protected virtual void OnEndApplyEffect(object target)
        {
        }

        public void ApplyEffect(object target)
        {
            if (!IsApplying)
            {
                (target as MonoBehaviour).StartCoroutine(ApplyEffectCoroutine(target));
            }
        }


    }
}
