using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MyGame.Enemy
{
    public interface IEnemy
    {
        public void Attack();
        public void Die();
        public void LookForPlayer();
    }
}

