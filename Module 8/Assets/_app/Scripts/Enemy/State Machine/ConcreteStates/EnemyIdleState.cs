using UnityEngine;

namespace _app.Scripts.Enemy.Stata_Machine.ConcreteStates
{
    public class EnemyIdleState : EnemyState
    {
        private Vector3 _targetPos;
        private Vector3 _direction;
        public EnemyIdleState(Base.Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
        {
            
        }

        public override void EnterState()
        {
            base.EnterState();
            _targetPos = GetRandomPointInCircle();
        }

        public override void ExitState()
        {
            base.ExitState();
        }

        public override void FrameUpdate()
        {
            base.FrameUpdate();
            if (enemy.IsAggroed)
            {
                enemy.StateMachine.ChangeState(enemy.ChaseState);
            }
        
            _direction = (_targetPos - enemy.transform.position).normalized;
        
            enemy.MoveEnemy(_direction * enemy.RandomMovementSpeed);

            if ((enemy.transform.position - _targetPos).sqrMagnitude < 0.01f)
            {
                _targetPos = GetRandomPointInCircle();
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

        private Vector3 GetRandomPointInCircle()
        {
            return enemy.transform.position + (Vector3)UnityEngine.Random.insideUnitCircle * enemy.RandomMovementRange;
        }
    }
}
