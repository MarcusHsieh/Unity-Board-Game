using TMPro;
using UnityEngine;

namespace Com.InfallibleCode.Start_Here
{
    public class KeypadDisplay : MonoBehaviour
    {
        [SerializeField] private TMP_Text label;
        [SerializeField] private Keypad keypad;

        private void Update()
        {
            label.text = $"{keypad.CurrentInput:00000000}";
        }
    }
}