using GameMachine.Interfaces;
using UnityEngine;

namespace Ui
{
    public class UiSystem : MonoBehaviour, IAwakeListener, IStartListener, IPausedListener, IResumeListener, IFinished
    {
        [SerializeField] 
        private GameObject _startPunnel;
    
        [SerializeField] 
        private GameObject _finishPunnel;
    
        [SerializeField] 
        private GameObject _pausedPunnel;
    
        [SerializeField] 
        private GameObject _pausedButton;
        void IAwakeListener.Awake()
        {
            OnAwake();
        }
        void IStartListener.Start()
        {
            OnStart();
        }
        void IPausedListener.Pause()
        {
            OnPause();
        }
        void IResumeListener.Resume()
        {
            OnResume();
        }
        void IFinished.Finish()
        {
            OnFinished();
        }
        private void OnAwake()
        {
            _startPunnel.SetActive(true);
        }
        private void OnStart()
        {
            _startPunnel.SetActive(false);
            _pausedButton.SetActive(true);
        }
        private void OnPause()
        {
            _pausedButton.SetActive(false);
            _pausedPunnel.SetActive(true);
        }
        private void OnResume()
        {
            _pausedButton.SetActive(true);
            _pausedPunnel.SetActive(false);
        }
        private void OnFinished()
        {
            _pausedButton.SetActive(false);
            _finishPunnel.SetActive(true);
        }
    }
}
