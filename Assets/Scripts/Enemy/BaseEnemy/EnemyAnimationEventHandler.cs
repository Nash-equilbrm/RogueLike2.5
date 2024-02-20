using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MyGame.Enemy
{
    public class EnemyAnimationEventHandler : MonoBehaviour
    {
        [SerializeField] private BaseEnemy _enemySelf;

        private void Awake()
        {
            if( _enemySelf == null)
            {
                _enemySelf = transform.parent.GetComponent<BaseEnemy>();
            }
        }

        public void RaiseAttackEvent()
        {
            this.Broadcast(EventID.PlayerTakeDamageFromEnemy, _enemySelf);
        }
    }
}

