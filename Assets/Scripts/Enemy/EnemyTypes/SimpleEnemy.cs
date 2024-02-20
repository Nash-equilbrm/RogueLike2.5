using MyGame.PlayerControl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MyGame.Enemy
{
    public class SimpleEnemy : BaseEnemy
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private float _detectPlayerRange;
        [SerializeField] private float _attackRange;
        [SerializeField] private float _speed;
        [SerializeField] private float _attackInterval = 0.5f;
        [SerializeField] private float _attackTimer;


        private void OnDrawGizmos()
        {
            UnityEditor.Handles.color = Color.yellow;
            UnityEditor.Handles.DrawWireDisc(transform.position, Vector3.up, _attackRange);
            UnityEditor.Handles.DrawWireDisc(transform.position, Vector3.up, _detectPlayerRange);
        }

        #region State Management

        internal override bool FindPlayer(Player p)
        {
            if(p == null) return false;
            return Vector3.SqrMagnitude(p.transform.position - transform.position) <= _detectPlayerRange * _detectPlayerRange;
        }

        internal override bool IsDead()
        {
            return base.IsDead();
        }

        internal override void OnAttackUpdate()
        {
            if(_attackTimer >= _attackInterval)
            {
                _animator.SetTrigger("attack");
                _attackTimer = 0f;
            }
            else
            {
                _attackTimer += Time.deltaTime;
            }
        }

        internal override void OnChasingPlayerUpdate(Player p)
        {
            if(p == null) return;
            Vector3 direction = (p.transform.position - transform.position);
            direction.Normalize();
            if(direction.x < 0f)
            {
                transform.localScale = Vector3.one;
            }
            else if(direction.x > 0f)
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }
            transform.Translate(direction * _speed * Time.deltaTime);
        }

        internal override void OnDeadUpdate()
        {
            base.OnDeadUpdate();
        }

        internal override void OnPatrolUpdate()
        {
            base.OnPatrolUpdate();
        }

        internal override bool ReachPlayer(Player p)
        {
            if (p == null) return false;
            return Vector3.SqrMagnitude(p.transform.position - transform.position) <= _attackRange * _attackRange;
        }

        internal override void ResetEnemy()
        {
            base.ResetEnemy();
        }

        internal override void OnAttackStart()
        {
            _attackTimer = _attackInterval;
        }

        internal override void OnAttackEnd()
        {
            base.OnAttackEnd();
        }

        internal override void OnChasingPlayerStart()
        {
            _animator.SetBool("isMoving", true);
        }

        internal override void OnChasingPlayerEnd()
        {
            _animator.SetBool("isMoving", false);
        }

        internal override void OnDeadStart()
        {
            base.OnDeadStart();
        }

        internal override void OnDeadEnd()
        {
            base.OnDeadEnd();
        }

        internal override void OnPatrolStart()
        {
            base.OnPatrolStart();
        }

        internal override void OnPatrolEnd()
        {
            base.OnPatrolEnd();
        }
        #endregion


        public override void TakeDamage(float damage)
        {
            base.TakeDamage(damage);
        }

        protected override void DoAttack(Player p)
        {
            base.DoAttack(p);
        }
    }
}

