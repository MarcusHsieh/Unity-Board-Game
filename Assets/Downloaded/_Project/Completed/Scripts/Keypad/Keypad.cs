using UnityEngine;
using UnityEngine.Events;

namespace Com.InfallibleCode.Completed
{
    public class Keypad : MonoBehaviour
    {
        [SerializeField] private int[] code;
        [SerializeField] private UnityEvent unlocked;

        private int _index;
        private int[] _currentInput;

        private void Awake()
        {
            _currentInput = new int[code.Length];
            _index = 0;
        }

        public bool IsUnlocked => Code == CurrentInput;

        public int Code
        {
            get
            {
                var result = 0;
                for (int i = 0, j = code.Length - 1; i < code.Length; i++, j--)
                {
                    result += (int) Mathf.Pow(10, j) * code[i];
                }

                return result;
            }
        }

        public int CurrentInput
        {
            get
            {
                var result = 0;
                for (int i = 0, j = _index - 1; i < _index; i++, j--)
                {
                    result += (int) Mathf.Pow(10, j) * _currentInput[i];
                }

                return result;
            }
        }

        public void Add(int value)
        {
            if (_index == code.Length) return;
            if (value < 0 || value > 9) return;
            _currentInput[_index] = value;
            _index++;
        }

        public void Enter()
        {
            if (IsUnlocked)
            {
                unlocked?.Invoke();
            }
        }

        public void Clear()
        {
            for (var i = 0; i < _currentInput.Length; i++)
            {
                _currentInput[i] = 0;
            }

            _index = 0;
        }
    }
}