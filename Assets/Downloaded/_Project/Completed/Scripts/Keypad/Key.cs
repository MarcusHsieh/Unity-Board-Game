using Com.InfallibleCode.Completed.Core;
using UnityEngine;

namespace Com.InfallibleCode.Completed
{
    public abstract class Key : MonoBehaviour, IInteractable
    {
        [SerializeField] protected Start_Here.Keypad Keypad;
        
        public abstract void Interact();
    }
}