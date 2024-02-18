using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;


namespace MyGame.Weapon
{
    public abstract class BulletTrajectory
    {
        //public Vector3 
        public abstract void MoveBullet(Bullet bullet);
        public abstract void ResetTrajectory();
    }
}