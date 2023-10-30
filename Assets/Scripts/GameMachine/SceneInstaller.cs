using Adapters;
using Enemy;
using Input;
using Player;
using Ui;
using Zenject;

namespace GameMachine
{
    public class SceneInstaller : MonoInstaller<SceneInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<GameStateMachine>().FromComponentInHierarchy().AsSingle();
            Container.Bind<LevelManager>().AsSingle();
      
            Container.BindInterfacesAndSelfTo<InputSystem>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerHealth>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerMove>().FromComponentInHierarchy().AsSingle();
            Container.Bind<EnemyDetector>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesAndSelfTo<UiSystem>().FromComponentInHierarchy().AsSingle();
        
            Container.BindInterfacesTo<MovementSystemAdapter>().AsSingle();
            Container.BindInterfacesTo<HealthAdapter>().AsSingle();
            Container.BindInterfacesTo<UIButtonsAdapter>().FromComponentInHierarchy().AsSingle();
        }
    }
}