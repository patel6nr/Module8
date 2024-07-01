namespace _app.Scripts.Enemy.Stata_Machine
{
    public class EnemyState
    {
        protected Base.Enemy enemy;
        protected EnemyStateMachine enemyStateMachine;

        public EnemyState(Base.Enemy enemy, EnemyStateMachine enemyStateMachine)
        {
            this.enemy = enemy;
            this.enemyStateMachine = enemyStateMachine;
        }

        protected EnemyState()
        {
            throw new System.NotImplementedException();
        }

        public virtual void EnterState(){ }

        public virtual void ExitState() { }
        public virtual void FrameUpdate() { }
        public virtual void PhysicsUpdate() { }
        public virtual void AnimationTriggerEvent(Base.Enemy.AnimationTriggerType triggerType) { }
    }
}

