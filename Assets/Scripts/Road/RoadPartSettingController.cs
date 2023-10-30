using System.Collections.Generic;
using GameMachine.Interfaces;
using UnityEngine;

namespace Road
{
    public class RoadPartSettingController : MonoBehaviour, IStartListener, ILateUpdateListener
    {
        public List<GameObject> RoadParts = new();
   
        [SerializeField] 
        private float _spawnZ = -25f;

        private GameObject _currentRoadPart;
        private float _roadPartLength;
        void IStartListener.Start()
        {
            _currentRoadPart = RoadParts[0];
            _roadPartLength = _currentRoadPart.GetComponent<MeshCollider>().bounds.size.z;
        }
        void ILateUpdateListener.LateUpdate(float deltaTime)
        {
            if (_currentRoadPart.transform.position.z <= _spawnZ)
                MoveRoadPartToStart();
        }
        private void MoveRoadPartToStart()
        {
            _currentRoadPart.transform.position 
                = new Vector3(0, 0, RoadParts[^1].transform.position.z + _roadPartLength); 
            RoadParts.RemoveAt(0);
            RoadParts.Add(_currentRoadPart);
            _currentRoadPart = RoadParts[0];
        }
    }
}
