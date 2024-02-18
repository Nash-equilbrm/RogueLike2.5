using MyGame.Weapon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLinearTrajectory : BulletTrajectory
{
    private Vector3 _targetDirection = Vector3.zero;
    public override void MoveBullet(Bullet bullet)
    {
        if (_targetDirection.Equals(Vector3.zero))
        {
            _targetDirection = (bullet.TargetPosition - bullet.transform.position);
            _targetDirection.y = 0f;
            _targetDirection.Normalize();
        }
        bullet.transform.Translate(_targetDirection * bullet.BulletSpeed * Time.deltaTime);
    }

    public override void ResetTrajectory()
    {
        _targetDirection = Vector3.zero;
    }
}
