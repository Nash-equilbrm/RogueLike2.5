using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MyGame.Weapon
{
    public interface IWeapon
    {
        bool CanAttack();
        void Attack(Vector3 targetPos = default(Vector3));
        void ResetWeapon();
        void OnReleased();
    }
}
