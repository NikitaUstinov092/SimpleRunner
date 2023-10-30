using GameMachine;
using GameMachine.Interfaces;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Adapters
{
    public class UIButtonsAdapter : MonoBehaviour, IAwakeListener, IStartListener, IPausedListener, IResumeListener, IFinished, IDisableListener
    {
        [SerializeField] 
        private Button _buttonStart;
    
        [SerializeField] 
        private Button _buttonPause;
    
        [SerializeField] 
        private Button _buttonResume;
    
        [SerializeField] 
        private Button _buttonRestart;
    
        private GameStateMachine _gameStateMachine;
        private LevelManager _levelManager;

        [Inject]
        private void Construct(GameStateMachine gameStateMachine, LevelManager levelManager)
        {
            _gameStateMachine = gameStateMachine;
            _levelManager = levelManager;
        }
        void IAwakeListener.Awake()
        {
            AddButtonStartListener();
        }
        void IStartListener.Start()
        {
            RemoveButtonStartListener();
            AddButtonPauseListener();
        }
        void IPausedListener.Pause()
        {
            RemoveButtonPauseListener();
            AddButtonResumeListener();
        }
        void IResumeListener.Resume()
        {
            AddButtonPauseListener();
            RemoveButtonResumeListener();
        }
        void IFinished.Finish()
        {
            AddButtonRestartListener();
            RemoveButtonPauseListener();
            RemoveButtonResumeListener();
        }
        void IDisableListener.Disable()
        {
            RemoveButtonStartListener();
            RemoveButtonPauseListener();
            RemoveButtonResumeListener();
            RemoveButtonRestartListener();
        }
        private void AddButtonStartListener()
        {
            _buttonStart.onClick.AddListener(_gameStateMachine.StartGame);
        }
        private void AddButtonPauseListener()
        {
            _buttonPause.onClick.AddListener(_gameStateMachine.PauseGame);
        }
        private void AddButtonResumeListener()
        {
            _buttonResume.onClick.AddListener(_gameStateMachine.ResumeGame);
        }
        private void AddButtonRestartListener()
        {
            _buttonRestart.onClick.AddListener(_levelManager.RestartScene);
        }
        private void RemoveButtonStartListener()
        {
            _buttonStart.onClick.RemoveListener(_gameStateMachine.StartGame);
        }
        private void RemoveButtonPauseListener()
        {
            _buttonPause.onClick.RemoveListener(_gameStateMachine.PauseGame);
        }
        private void RemoveButtonResumeListener()
        {
            _buttonResume.onClick.RemoveListener(_gameStateMachine.PauseGame);
        }
        private void RemoveButtonRestartListener()
        {
            _buttonRestart.onClick.RemoveListener(_levelManager.RestartScene);
        }
    }
}

