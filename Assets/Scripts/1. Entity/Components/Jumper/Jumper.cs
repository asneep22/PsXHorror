using EntitySystem.Components;
using UnityEngine;

namespace EntitySystem.Components
{
    public class Jumper : EntityComponent, IInitializable
    {
        [SerializeField] private float _strength = 100;
        [SerializeField] private Jumpers _jumper_on_start;
        private IJumpable _jumpable;
        private GroundChecker _ground_checker;

        private Rigidbody _rigidbody;

        public float Strength
        {
            get => _strength;
            private set
            {
                _strength = value < 0 ? 0 : value;
            }
        }

        public enum Jumpers
        {
            InputCharacterJumper
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

            ResetJumper();



            _rigidbody = rb;
            _ground_checker = ground_checker;
        }

        private void Update()
        {
            Jump(_jumpable);
        }

        public void Jump(IJumpable jumpable)
        {
            if (_ground_checker && _ground_checker.IsOnGround)
                jumpable.Jump(_rigidbody, Strength);
        }

        public void ResetJumper()
        {
            switch (_jumper_on_start)
            {
                case Jumpers.InputCharacterJumper:
                    _jumpable = new InputCharacterJumper();
                    break;
            }
        }
    }
}