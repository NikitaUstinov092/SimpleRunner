using System;
using GameMachine.Interfaces;
using UnityEngine;

namespace Input
{
    public class InputSystem : MonoBehaviour, IUpdateListener
    {
        public event Action<int> OnPressedInputButton;
        void IUpdateListener.Update(float time)
        {
            HandleKeyboard();
        }
        private void HandleKeyboard()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.LeftArrow))
                OnPressedInputButton?.Invoke(0);

            else if (UnityEngine.Input.GetKeyDown(KeyCode.RightArrow))
                OnPressedInputButton?.Invoke(1);
        }

    }
}
