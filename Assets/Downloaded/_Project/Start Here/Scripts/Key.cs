using UnityEngine;

namespace Com.InfallibleCode.Start_Here
{
    public abstract class Key : MonoBehaviour, IInteractable
    {
        [SerializeField] protected Keypad Keypad;
        
        public abstract void Interact();
    }
}