using UnityEngine;

namespace _app.Scripts.Enemy.Trigger_Checks
{
   public class EnemyAggroCheck : MonoBehaviour
   {
      public GameObject PlayerTarget { get; set; }
      public Base.Enemy _enemy;

      private void Awake()
      {
         PlayerTarget = GameObject.FindGameObjectWithTag("Player");
      }

      private void OnTriggerEnter2D(Collider2D collision)
      {
         if (collision.gameObject == PlayerTarget)
         {
            _enemy.SetAggroStatus(true);
         }
      }

      private void OnTriggerExit2D(Collider2D other)
      {
         if (collision.gameObject == PlayerTarget)
         {
            _enemy.SetAggroStatus(false);
         }
      }
   }
}