using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Tools;
using UnityEngine;


namespace MyGame.ObjectPool
{
    public class ParticleFXPool : ResourceManager<Transform>
    {
        [SerializeField] private Transform _fxPrefabs;
        private void Start()
        {
            int fxCount = _fxPrefabs.childCount;
            Transform[] l = new Transform[fxCount];
            for (int i = 0; i < fxCount; i++)
            {
                l[i] = _fxPrefabs.GetChild(i);
            }
            if(l != null)
            {
                foreach (var fx in l)
                {
                    var pool = CreatePool(fx.name, fx.gameObject);
                    pool.Prepare(5);
                }
            }
        }

    }
}

