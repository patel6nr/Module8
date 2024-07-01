using _app.Scripts.Enemy.Interfaces;
using _app.Scripts.Enemy.Stata_Machine;
using _app.Scripts.Enemy.Stata_Machine.ConcreteStates;
using Unity.VisualScripting;
using UnityEngine;

namespace _app.Scripts.Enemy.Base
{
    public class Enemy : MonoBehaviour, IDamageable, IEnemyMoveable, ITriggerCheckable
    {
        [field: SerializeField] public float MaxHealth { get; set; } = 100f;
        public float CurrentHealth { get; set; }
        public Rigidbody2D RB { get; set; }
        public bool IsFacingRight { get; set; } = true;

        public bool IsAggroed { get; set; }

        public bool IsWithinStrikingDistance { get; set; }

        public void Awake()
        {
            StateMachine = new EnemyStateMachine();

            IdleState = new EnemyIdleState(this, StateMachine);
            ChaseState = new EnemyChaseState(this, StateMachine);
            AttackState = new EnemyAttackState(this, StateMachine);
        }

        public void Start()
        {
            CurrentHealth = MaxHealth;
            RB = GetComponent<Rigidbody2D>();

            StateMachine.Initialize(IdleState);
        }

        private void Update()
        {
            StateMachine.CurrentEnemyState.FrameUpdate();
        }

        private void FixedUpdate()
        {
            StateMachine.CurrentEnemyState.PhysicsUpdate();
        }

        #region State Machine Variables

        public EnemyStateMachine StateMachine { get; set; }
        public EnemyIdleState IdleState { get; set; }
        public EnemyChaseState ChaseState { get; set; }
        public EnemyAttackState AttackState { get; set; }

        #endregion

        #region Idle Variables

        public float RandomMovementRange = 5f;
        public float RandomMovementSpeed = 1f;

        #endregion

        #region Health/Die Functions

        public void Damage(float damageAmount)
        {
            CurrentHealth -= damageAmount;
            if (CurrentHealth <= 0f)
            {
                Die();
            }
        }

        public void Die()
        {

        }

        #endregion

        #region Movement Fuctions




        public void MoveEnemy(Vector2 velocity)
        {
            RB.velocity = velocity;
            CheckForLeftOrRightFacing(velocity);
        }

        public void CheckForLeftOrRightFacing(Vector2 velocity)
        {
            if (IsFacingRight && velocity.x < 0f)
            {
                Vector3 rotator = new Vector3(transform.rotation.x, 180f, transform.rotation.z);
                transform.rotation = Quaternion.Euler(rotator);
                IsFacingRight = !IsFacingRight;
            }
            else if (!IsFacingRight && velocity.x > 0f)
            {
                Vector3 rotator = new Vector3(transform.rotation.x, 0f, transform.rotation.z);
                transform.rotation = Quaternion.Euler(rotator);
                IsFacingRight = !IsFacingRight;
            }
        }

        #endregion

        #region Distance Checks

        public void SetAggroStatus(bool isAggroed)
        {
            isAggroed = isAggroed;
        }

        public void SetStrikingDistanceBool(bool isWithinStrickingDistance)
        {
            isWithinStrickingDistance = isWithinStrickingDistance;
        }
    }

    #endregion

    #region Animation Triggers

    private void AnimationTriggerEvent(AnimationTriggerType triggerType)
    {
        StateMachine.CurrentEnemyState.AnimationTriggerEvent(triggerType);
    }

    public enum AnimationTriggerType
    {
        EnemyDamaged,
        PlayFootStepSound
    }

    #endregion
