using MyGame.Effects;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MyGame.Enemy
{
    public partial class BaseEnemy
    {
        [Header("Effect Management")]
        [SerializeField] private List<EffectBase> _effects = new List<EffectBase>();
        private List<EffectBase> _effectsToRemove = new List<EffectBase>();

        public void AddEffect(EffectBase effect)
        {
            if (!_effects.Contains(effect)){
                _effects.Add(effect);
            }
        }

        private void UpdateEffects()
        {
            foreach(EffectBase effect in _effects)
            {
                if (effect.IsDone)
                {
                    _effectsToRemove.Add(effect);
                    continue;
                }
                effect.ApplyEffect(this);
            }
            if(_effectsToRemove.Count > 0)
            {
                _effects = _effects.Except(_effectsToRemove).ToList();
            }
        }

    }
}
