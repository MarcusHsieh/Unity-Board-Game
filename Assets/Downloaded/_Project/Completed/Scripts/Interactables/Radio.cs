using Com.InfallibleCode.Completed.Core;
using UnityEngine;

namespace Com.InfallibleCode.Completed.Interactables
{
    public class Radio : MonoBehaviour, IInteractable
    {
        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void Toggle()
        {
            _audioSource.mute = !_audioSource.mute;
        }

        public void Interact()
        {
            Toggle();
        }
    }
}