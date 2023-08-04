using EntitySystem.Components;
using UnityEngine;

namespace EntitySystem.Components
{
    public class Mover : EntityComponent, IInitializable, IMovable
    {
        [SerializeField] private float _speed_fade_off_strength = 10f;
        [SerializeField] private float _speed = 10f;

        private Rigidbody _rigidbody;
        private Vector3 _current_velocity;
        private bool _is_movement_locked;

        public float Speed { get => _speed; }
        public Rigidbody Rigidbody { get => _rigidbody; }

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
            if (_is_movement_locked)
                new_direction = Vector3.zero;

            _current_velocity = Vector3.Lerp(_current_velocity, new_direction * _speed, Time.fixedDeltaTime * _speed_fade_off_strength);
            _rigidbody.velocity = _current_velocity;
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
