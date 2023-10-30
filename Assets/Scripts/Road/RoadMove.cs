using GameMachine.Interfaces;
using UnityEngine;

namespace Road
{
    public class RoadMove : MonoBehaviour, IUpdateListener
    {
        private float _zPosition;
        private const float Speed = 16f;
        void IUpdateListener.Update(float time)
        {
            var roadTransform = transform;
            var position = roadTransform.position;
            _zPosition = position.z;
            position = new Vector3(position.x, position.y, _zPosition - Speed * Time.deltaTime);
            roadTransform.position = position;
        }
    }
}
