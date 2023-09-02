using EntitySystem.Components;
using NaughtyAttributes;
using System.Collections.Generic;
using UnityEngine;

namespace EntitySystem.Components
{
    public class Mover : EntityComponent, IInitializable, IMovable
    {
        [SerializeField] private float _speed_fade_off_strength = 10f;
        [SerializeField] private float _speed = 10f;

        private Rigidbody _rigidbody;
        private Vector3 _movement_direction;
        private float _current_speed;
        private bool _is_movement_locked;

        public Rigidbody Rigidbody { get => _rigidbody; }
        public Vector3 Movement_direction { get => _movement_direction; }
        public float Speed { get => _current_speed; }

        public void Initialize()
        {
            if (Entity.TryGetComponent(out Rigidbody rb))
            {
                _rigidbody = rb;
                return;
            }

            throw new System.Exception($"''{Entity.name}'' doesn't has Rigidbody");
        }

        public virtual void Move(Vector3 new_direction)
        {
            float new_speed = _speed;

            if (_is_movement_locked || new_direction.magnitude == 0)
                new_speed = 0;

            _current_speed = Mathf.Lerp(_current_speed, new_speed, Time.fixedDeltaTime * _speed_fade_off_strength);
            _rigidbody.velocity = _movement_direction * _current_speed;
            _movement_direction = new_direction;
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
