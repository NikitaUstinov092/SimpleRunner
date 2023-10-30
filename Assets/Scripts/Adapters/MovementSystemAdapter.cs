using GameMachine.Interfaces;
using Input;
using Player;
using Zenject;

namespace Adapters
{
    public class MovementSystemAdapter : IStartListener, IFinished
    {
        private InputSystem _keyBoardInput;
        private PlayerMove _playerMove;

        [Inject]
        private void Construct(InputSystem keyBoardInput, PlayerMove playerMove)
        {
            _keyBoardInput = keyBoardInput;
            _playerMove = playerMove;
        }
        void IStartListener.Start()
        {
            AddKeyBoardPlayerListener();
        }
        void IFinished.Finish()
        {
            RemoveKeyBoardPlayerListener();
        }
        private void AddKeyBoardPlayerListener()
        {
            _keyBoardInput.OnPressedInputButton += _playerMove.SetDirection;
        }
        private void RemoveKeyBoardPlayerListener()
        {
            _keyBoardInput.OnPressedInputButton -= _playerMove.SetDirection;
        }
    }
}
