using _app.Scripts.Enemy.Base;

namespace _app.Scripts.Enemy.Stata_Machine.ConcreteStates
{
    public class EnemyAttackState : EnemyState
    {
        public EnemyAttackState(Base.Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
        {
        
        }

        public override void EnterState()
        {
            base.EnterState();
        }

        public override void ExitState()
        {
            base.ExitState();
        }

        public override void FrameUpdate()
        {
            base.FrameUpdate();
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
    