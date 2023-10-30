using System;
using UnityEngine;

namespace Player
{
    public class PlayerHealth : MonoBehaviour
    {
        public event Action OnDeath;
    
        [SerializeField] 
        private float _health;
        public void TakeDamage(float damage)
        {
            _health -= damage;
            CheckDeath();
        }
        private void CheckDeath()
        {
            if (_health <= 0)
                OnDeath?.Invoke();
        }
    }
}
