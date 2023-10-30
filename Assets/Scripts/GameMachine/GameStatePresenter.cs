using UnityEngine;
using UnityEngine.Events;

namespace GameMachine
{
    public class GameStatePresenter : MonoBehaviour
    {
        public UnityEvent OnFinish;
        public UnityEvent OnRestart;
        public UnityEvent OnPause;
        public UnityEvent OnResume;
        public UnityEvent OnStart;

    }
}
