using UnityEngine;

namespace _app.Scripts.Enemy.Interfaces
{
    public interface IEnemyMoveable
    {
        Rigidbody2D RB { get; set; }
        bool IsFacingRight { get; set; }
        void MoveEnemy(Vector2 velocity);
        void CheckForLeftOrRightFacing(Vector2 velocity);

    }
}
