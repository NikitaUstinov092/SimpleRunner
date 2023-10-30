using UnityEngine;

namespace Enemy
{
    public class Enemy : MonoBehaviour, IDamage
    {
        [SerializeField]
        private float _damage = 100f;
        float IDamage.GetDamage()
        {
            return _damage;
        }
    }
    public interface IDamage
    {
        float GetDamage();
    }
}