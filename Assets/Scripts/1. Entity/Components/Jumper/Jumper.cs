using EntitySystem.Components;
using UnityEngine;

namespace EntitySystem.Components
{
    public class Jumper : EntityComponent, IInitializable, IJumpable
    {
        private GroundChecker _ground_checker;
        private RigidbodyFaller _rigidbody_faller;
        [SerializeField] private float _strength = 100;

        private Rigidbody _rigidbody;

        public float Strength
        {
            get => _strength;
            private set
            {
                _strength = value < 0 ? 0 : value;
            }
        }

        public void Initialize()
        {
            if (!Entity.TryGetComponent(out Rigidbody rb))
                throw new System.Exception($"''{Entity.name}'' doesn't has Rigidbody");

            if (!Entity.TryGet(out GroundChecker ground_checker))
            {
                Destroy(gameObject);
                throw new System.Exception($" add to ''{Entity.name}'' ground cheker. Jumper was deleted");
            }

            if (!Entity.TryGet(out RigidbodyFaller rigidbodyFaller))
            {
                Destroy(gameObject);
                throw new System.Exception($" add to ''{Entity.name}'' ground cheker. Jumper was deleted");
            }

            _rigidbody = rb;
            _ground_checker = ground_checker;
            _rigidbody_faller = rigidbodyFaller;
        }

        public virtual void Jump()
        {
            if (!_ground_checker.IsOnGround)
                return;

            _ground_checker.BeginCheck();
            Vector3 velocity = _rigidbody.velocity;
            velocity.y = Strength;
            _rigidbody_faller.SetYVelocity(Strength);
        }
    }
}