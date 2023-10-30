using System.Collections.Generic;
using GameMachine.Interfaces;
using UnityEngine;
using Zenject;

namespace GameMachine
{
    public enum GameState
    {
        OFF = 0,
        PLAYING = 1,
        PAUSED = 2,
        FINISHED = 3
    }

    public class GameStateMachine : MonoBehaviour
    {
        [SerializeField] 
        private GameState _state;

        [Inject]
        private readonly DiContainer _container;
    
        public void StartGame()
        {
            foreach (var listener in _container.Resolve<IEnumerable<IStartListener>>())
            {
                listener.Start();
            }
            _state = GameState.PLAYING;
        }
        public void FinishGame()
        {
            foreach (var listener in _container.Resolve<IEnumerable<IFinished>>())
            {
                listener.Finish();
            }
            _state = GameState.FINISHED;
        }
        private void Awake()
        {
            Init();
        }
        private void Update()
        {
            if (_state != GameState.PLAYING)
                return;

            foreach (var listener in _container.Resolve<IEnumerable<IUpdateListener>>())
            {
                listener.Update(Time.deltaTime);
            }
        }
        private void LateUpdate()
        {
            if (_state != GameState.PLAYING)
                return;

            foreach (var listener in _container.Resolve<IEnumerable<ILateUpdateListener>>())
            {
                listener.LateUpdate(Time.deltaTime);
            }
        }
        private void OnDisable()
        {
            foreach (var listener in _container.Resolve<IEnumerable<IDisableListener>>())
            {
                listener.Disable();
            }
        }
        private void Init()
        {
            foreach (var listener in _container.Resolve<IEnumerable<IAwakeListener>>())
            {
                listener.Awake();
            }
            _state = GameState.OFF;
        }
        public void PauseGame()
        {
            foreach (var listener in _container.Resolve<IEnumerable<IPausedListener>>())
            {
                listener.Pause();
            }
            _state = GameState.PAUSED;
        }
        public void ResumeGame()
        {
            foreach (var listener in _container.Resolve<IEnumerable<IResumeListener>>())
            {
                listener.Resume();
            }
            _state = GameState.PLAYING;
        }
    }
}