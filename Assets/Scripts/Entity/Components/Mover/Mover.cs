using EntitySystem.Components;
using UnityEngine;

namespace EntitySystem.Components
{
    public class Mover : EntityComponent, IInitializable, IMovable
    {
        [SerializeField] private float _speed_fade_off_strength = 10f;
        private Rigidbody _rigidbody;

        private bool _is_movement_locked;

        public void Initialize()
        {
            if (Entity.TryGetComponent(out Rigidbody rb))
            {
                _rigidbody = rb;
                return;
            }

            throw new System.Exception($"''{Entity.name}'' doesn't has Rigidbody");
        }

        public virtual void Move(Vector3 new_direction, float speed)
        {
            if (_is_movement_locked)
                new_direction = Vector3.zero;

            Vector3 lerped_velocity = Vector3.Lerp(_rigidbody.velocity, new_direction, Time.fixedDeltaTime * _speed_fade_off_strength) * speed;
            _rigidbody.velocity = new(lerped_velocity.x, _rigidbody.velocity.y, lerped_velocity.z);
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
