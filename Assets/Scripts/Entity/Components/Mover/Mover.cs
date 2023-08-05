using EntitySystem.Components;
using NaughtyAttributes;
using UnityEngine;

namespace EntitySystem.Components
{
    public class Mover : EntityComponent, IInitializable, IMovable
    {
        [SerializeField] private float _speed_fade_off_strength = 10f;
        [SerializeField] private float _speed = 10f;

        private Rigidbody _rigidbody;
        private Vector3 _current_direction;
        private bool _is_movement_locked;
        private float _current_speed;

        public float Speed { get => _current_speed; }
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
                return;

            float new_speed = new_direction.magnitude == 0 ? 0 : _speed;
            _current_speed = Mathf.Lerp(_current_speed, new_speed, Time.fixedDeltaTime * _speed_fade_off_strength);
            _rigidbody.velocity = new_direction * _current_speed;
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
