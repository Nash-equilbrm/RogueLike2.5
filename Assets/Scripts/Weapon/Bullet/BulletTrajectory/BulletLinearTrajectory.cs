using MyGame.Weapon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLinearTrajectory : BulletTrajectory
{
    public override void MoveBullet(Bullet bullet)
    {
        if (CurrentDirection.Equals(Vector3.zero))
        {
            CurrentDirection = (bullet.TargetPosition - bullet.transform.position);
            CurrentDirection = Vector3.Scale(CurrentDirection, new Vector3(1f, 0f, 1f));
            CurrentDirection = CurrentDirection.normalized;
        }
        bullet.transform.Translate(CurrentDirection * bullet.BulletSpeed * Time.deltaTime);
    }

    public override void ResetTrajectory()
    {
        CurrentDirection = Vector3.zero;
    }
}
