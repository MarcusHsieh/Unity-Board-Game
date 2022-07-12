using UnityEngine;

namespace Com.InfallibleCode.Start_Here
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