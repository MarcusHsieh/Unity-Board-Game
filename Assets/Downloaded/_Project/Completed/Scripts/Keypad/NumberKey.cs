using UnityEngine;

namespace Com.InfallibleCode.Completed
{
    public class NumberKey : Key
    {
        [SerializeField] private int value;
        
        public override void Interact()
        {
            Keypad.Add(value);
        }
    }
}