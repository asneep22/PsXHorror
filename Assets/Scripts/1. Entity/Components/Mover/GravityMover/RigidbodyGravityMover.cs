using EntitySystem.Components;
using NaughtyAttributes;
using System.Collections.Generic;
using UnityEngine;

namespace EntitySystem.Components
{
    public class RigidbodyGravityMover : RigidbodyFaller, IInitializable, IMovable
    {
        [SerializeField] private float _speed_fade_off_strength = 10f;
        [SerializeField] private float _speed = 10f;

        private Rigidbody _rigidbody;
        private Vector3 _movement_direction;
        private float _fade_speed;
        private bool _is_movement_locked;

        public Rigidbody Rigidbody { get => _rigidbody; }
        public Vector3 Movement_direction { get => _movement_direction; set => _movement_direction = value; }
        public float Speed { get => _speed; }
        public float FadeSpeed { get => _fade_speed; private set => _fade_speed = value; }

        public override void Initialize()
        {
            base.Initialize();

            if (!Entity.TryGetComponent(out Rigidbody rb))
                throw new System.Exception($"''{Entity.name}'' doesn't has Rigidbody");

            _rigidbody = rb;
        }

        public virtual void Move(Vector3 new_direction, float speed)
        {
            if (_is_movement_locked)
                return;

            float new_speed = new_direction.x + new_direction.z == 0 ? 0 : speed;
            FadeSpeed = Mathf.Lerp(FadeSpeed, new_speed, Time.deltaTime * _speed_fade_off_strength);

            if (new_direction.normalized.magnitude != 0)
                Movement_direction = new(new_direction.normalized.x, Y_velocity, new_direction.normalized.z);

            _rigidbody.velocity = Movement_direction * FadeSpeed;
        }

        public void LockMovement()
        {
            _is_movement_locked = true;
        }

        public void UnlockMovement()
        {
            _is_movement_locked = false;
        }
    }
}
