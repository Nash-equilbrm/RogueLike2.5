using MyGame.Effects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MyGame.Enemy
{
    public class EnemyEffectManager: MonoBehaviour
    {
        [Header("Effect Management")]
        [SerializeField] private BaseEnemy _enemy;
        private Dictionary<string, EffectBase> _effects = new Dictionary<string, EffectBase>();

        
        private void Update()
        {
            foreach (EffectBase effect in _effects.Values)
            {
                if (effect.IsDone)
                {
                    continue;
                }
                effect.ApplyEffect(_enemy);
            }
        }

        private void AddEffect(string key, EffectBase effect)
        {
            if (!_effects.ContainsKey(key))
            {
                _effects.Add(key, effect);
            }

            _effects[key].Reset();
        }

        public EffectBase GetEffect(Type T)
        {
            string key = T.Name;
            if (!_effects.ContainsKey(key))
            {
                EffectBase effect = Activator.CreateInstance(T) as EffectBase;
                AddEffect(key, effect);
                return effect;
            }
            else
            {
                return _effects[key];
            }
        }

    }
}
