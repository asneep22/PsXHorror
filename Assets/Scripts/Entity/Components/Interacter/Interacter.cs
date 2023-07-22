using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EntitySystem.Components
{
    public class Interacter : EntityComponent
    {
        [SerializeField] private float _distance = 30;
        [SerializeField] private LayerMask _interactable_layer;

        private Camera _camera;

        private void Start()
        {
            if (_camera != null)
                return;

            Reset();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
                Interact();
        }

        public void Interact()
        {
            Ray ray = new(_camera.transform.position, _camera.transform.forward * _distance);

            if (!Physics.Raycast(ray, out RaycastHit hit_data, _interactable_layer))
                return;

            if (!hit_data.collider.TryGetComponent(out Entity entity))
                return;

            if (!entity.Check<IInteractable>())
                return;

            entity.Get<IInteractable>().Handle(Entity);

        }

        private void OnDrawGizmos()
        {
            if (_camera == null)
                return;

            Gizmos.color = Color.green;
            Gizmos.DrawRay(_camera.transform.position, _camera.transform.forward * _distance);
        }

        public override void Reset()
        {
            base.Reset();
            _camera = Camera.main;

            if (_camera == null)
                throw new System.Exception("Add to main camera tag 'MainCamera'");
        }
    }

}

