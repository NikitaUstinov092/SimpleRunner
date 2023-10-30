namespace GameMachine.Interfaces
{
    public interface IGameListener
    {

    }
    public interface IAwakeListener : IGameListener
    {
        void Awake();
    }

    public interface IStartListener: IGameListener
    {
        void Start();
    }

    public interface IPausedListener : IGameListener
    {
        void Pause();
    }

    public interface IResumeListener : IGameListener
    {
        void Resume();
    }

    public interface IFinished : IGameListener
    {
        void Finish();
    }

    public interface IDisableListener : IGameListener
    {
        void Disable();
    }

    public interface IUpdateListener : IGameListener
    {
        void Update(float time);
    }

    public interface ILateUpdateListener : IGameListener
    {
        void LateUpdate(float time);
    }
}