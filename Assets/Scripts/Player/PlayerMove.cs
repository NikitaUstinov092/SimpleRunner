using DG.Tweening;
using GameMachine.Interfaces;
using UnityEngine;

namespace Player
{
    public class PlayerMove : MonoBehaviour, IStartListener, IPausedListener, IResumeListener, IFinished
    {
        [SerializeField] 
        private Transform _leftPoint;
    
        [SerializeField] 
        private Transform _rightPoint;
    
        [SerializeField] 
        private Transform _zeroPoint;

        [SerializeField] 
        private float _speedDuration = 0.5f;
    
        private Transform _currentPoint;
        
        private Tweener _tweener;

        void IStartListener.Start()
        {
            _currentPoint = _zeroPoint;
        }
        void IPausedListener.Pause()
        {
            _tweener.Pause();
        }
        void IResumeListener.Resume()
        {
            _tweener.Play();
        }
        void IFinished.Finish()
        {
            _tweener.Kill();
        }
        public void SetDirection(int direction)
        {
            if (direction == 0)
            {
                if (_currentPoint == _leftPoint)
                    return;
                SetDirection(_rightPoint, _leftPoint);
            }
            else
            {
                if (_currentPoint == _rightPoint)
                    return;
                SetDirection(_leftPoint, _rightPoint);
            }
        }
        private void SetDirection(Object extremePoint, Transform nextPoint)
        {
            if (_currentPoint == extremePoint)
            {
                Move(_zeroPoint.position, _zeroPoint);
                return;
            }

            if (_currentPoint != _zeroPoint)
                return;

            Move(nextPoint.position, nextPoint);
        }
        private void Move(Vector3 targetPos, Transform newCurrentPoint)
        {
            _tweener.Kill();
            _tweener = transform.DOMove(targetPos, _speedDuration).SetAutoKill(false).SetUpdate(UpdateType.Normal, true);
            _currentPoint = newCurrentPoint;
        }
    }
}


