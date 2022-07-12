using UnityEngine;

namespace Com.InfallibleCode.Completed.Core
{
    public class Player : MonoBehaviour
    {
        private Camera _camera;

        private void Start()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            var nearestGameObject = GetNearestGameObject();
            if (nearestGameObject == null) return;
            if (Input.GetButtonDown("Fire1"))
            {
                var interactable = nearestGameObject.GetComponent<IInteractable>();
                interactable?.Interact();
            }
        }

        private GameObject GetNearestGameObject()
        {
            GameObject result = null;
            var ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hit, 3))
            {
                result = hit.transform.gameObject;
            }
            return result;
        }
    }
}