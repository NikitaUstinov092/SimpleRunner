using Enemy;
using GameMachine;
using GameMachine.Interfaces;
using Player;
using Zenject;

namespace Adapters
{
    public class HealthAdapter: IStartListener, IFinished
    {
        private PlayerHealth _health;
        private EnemyDetector _enemyDetector;
        private GameStateMachine _gameStateMachine;

        [Inject]
        private void Construct(PlayerHealth health, EnemyDetector enemyDetector, GameStateMachine gameStateMachine)
        {
            _health = health;
            _enemyDetector = enemyDetector;
            _gameStateMachine = gameStateMachine;
        }
        void IStartListener.Start()
        {
            _enemyDetector.OnEnemyDetected += _health.TakeDamage;
            AddDeathListener();
        }
        void IFinished.Finish()
        {
            _enemyDetector.OnEnemyDetected -= _health.TakeDamage;
            RemoveDeathListener();
        }
        private void AddDeathListener()
        {
            _health.OnDeath += _gameStateMachine.FinishGame;
        }
        private void RemoveDeathListener()
        {
            _health.OnDeath += _gameStateMachine.FinishGame;
        }
    }
}
