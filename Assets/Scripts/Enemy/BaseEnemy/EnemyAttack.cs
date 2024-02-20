using MyGame.PlayerControl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MyGame.Enemy
{
    public abstract partial class BaseEnemy
    {
        protected virtual void DoAttack(Player p)
        {
            Debug.Log(gameObject.name + " attack " + p.name);
        }
    }
}

