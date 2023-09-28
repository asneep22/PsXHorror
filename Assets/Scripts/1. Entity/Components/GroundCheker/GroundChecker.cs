using Helpers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EntitySystem.Components
{
    public class GroundChecker : EntityComponent
    {
        [SerializeField] private LayerMask layer;
        [SerializeField] private float _radius;
        [SerializeField] private float _check_time = .5f;
        private bool _is_on_ground;

        [Header("Editor")]
        [SerializeField] private Color _draw_color;

        public float CheckTime { get => _check_time; }
        public bool IsOnGround { get => _is_on_ground; }

        private void Start()
        {
            BeginCheck();
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = _draw_color;
            Gizmos.DrawSphere(transform.position, _radius);
        }

        public void BeginCheck()
        {
            _is_on_ground = false;
            CoroutineExtension.RepeatUntil(this, () => _is_on_ground == false, () => ConfirmGround(), _check_time);
        }

        private void ConfirmGround()
        {
            Collider[] overlapped = Physics.OverlapSphere(transform.position, _radius, layer);

            if (overlapped.Length > 0)
                _is_on_ground = true;
        }
    }
}
