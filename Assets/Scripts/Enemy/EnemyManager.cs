using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;

namespace MyGame.Enemy
{
    public class EnemyManager : Singleton<EnemyManager>
    {
        [SerializeField] private List<BaseEnemy> _enemies = new List<BaseEnemy>();

        public List<BaseEnemy> Enemies { get => _enemies; }
    }
}

