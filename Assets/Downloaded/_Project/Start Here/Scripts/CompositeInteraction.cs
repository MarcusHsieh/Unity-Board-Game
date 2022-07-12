using System.Collections.Generic;
using UnityEngine;

namespace Com.InfallibleCode.Start_Here
{
    public class CompositeInteraction : MonoBehaviour, IInteractable
    {
        [SerializeField] private List<GameObject> interactableGameObjects;

        public void Interact()
        {
            foreach (var interactableGameObject in interactableGameObjects)
            {
                var interactable = interactableGameObject.GetComponent<IInteractable>();
                if (interactable == null) continue;
                interactable.Interact();
            }
        }
    }
}