using GameMachine.Interfaces;
using UnityEngine;
using Zenject;

namespace GameMachine
{
    public class GameListenersInstaller : MonoInstaller<GameListenersInstaller>
    {
        [SerializeField] 
        private MonoBehaviour[] _allIListenersMono;
        public override void InstallBindings()
        {
            foreach (var t1 in _allIListenersMono)
            {
                var massComp = t1.GetComponents<MonoBehaviour>();

                foreach (var t in massComp)
                {
                    if (t is IGameListener listener)
                        Container.BindInterfacesTo(listener.GetType()).FromInstance(listener).AsCached();
                }
            }
        }
    }
}
