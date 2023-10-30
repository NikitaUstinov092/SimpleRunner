using System;
using UnityEngine;

namespace Enemy
{
    public class EnemyDetector : MonoBehaviour
    {
        public event Action<float> OnEnemyDetected; 
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent(out IDamage enemy))
            {
                OnEnemyDetected?.Invoke(enemy.GetDamage());
            }
        }
    }
}
