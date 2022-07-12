using TMPro;
using UnityEngine;

namespace Com.InfallibleCode.Completed
{
    public class KeypadDisplay : MonoBehaviour
    {
        [SerializeField] private TMP_Text label;
        [SerializeField] private Start_Here.Keypad keypad;

        private void Update()
        {
            label.text = $"{keypad.CurrentInput:00000000}";
        }
    }
}