using EntitySystem.Components;
using UnityEngine;

namespace EntitySystem.Components
{
    public class Jumper : EntityComponent, IInitializable, IJumpable
    {
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
            if (Entity.TryGetComponent(out Rigidbody rb))
            {
                _rigidbody = rb;
                return;
            }

            throw new System.Exception($"''{Entity.name}'' doesn't has Rigidbody");
        }

        public virtual void Jump()
        {
            _rigidbody.AddForce(Vector3.up * Strength, ForceMode.Impulse);
        }
    }
}