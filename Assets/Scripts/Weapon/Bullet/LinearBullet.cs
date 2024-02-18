using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MyGame.Weapon
{
    public class LinearBullet : Bullet
    {
        [SerializeField] TrailRenderer _trailRenderer;
        private void Start()
        {
            Initialize(new BulletLinearTrajectory());
        }

        public override void ResetBullet()
        {
            base.ResetBullet();
            _trailRenderer.Clear();
        }
    }
}
