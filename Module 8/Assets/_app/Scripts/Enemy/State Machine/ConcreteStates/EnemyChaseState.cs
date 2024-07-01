using UnityEngine;

namespace _app.Scripts.Enemy.Stata_Machine.ConcreteStates
{
    public class EnemyChaseState : EnemyState
    {
        private Transform _playerTransform;
        private float _MovementSpeed = 1.75f;
        public EnemyChaseState(Base.Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
        {
            _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }

        public override void EnterState()
        {
            base.EnterState();
            Debug.Log("Hello from the chase state");
        }

        public override void ExitState()
        {
            base.ExitState();
        }

        public override void FrameUpdate()
        {
            base.FrameUpdate();

            Vector2 moveDirection = (_playerTransform.position - enemy.transform.position).normalized;
            enemy.MoveEnemy(moveDirection * _MovementSpeed);

            if (enemy.IsWithinStrikingDistance)
            {
                enemy.StateMachine.ChangeState(enemy.AttackState);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }

        public override void AnimationTriggerEvent(Base.Enemy.AnimationTriggerType triggerType)
        {
            base.AnimationTriggerEvent(triggerType);
        }
    }
}
