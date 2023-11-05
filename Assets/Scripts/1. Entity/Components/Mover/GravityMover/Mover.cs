using EntitySystem.Components;
using NaughtyAttributes;
using System.Collections.Generic;
using UnityEngine;

namespace EntitySystem.Components
{
    public class Mover : EntityComponent, IInitializable
    {
        [SerializeField] private Movers _start_mover;
        [SerializeField] private float _max_speed = 10f;

        private IMovable _movable;

        public Rigidbody Rigidbody { get; private set; }
        public float Max_speed { get => _max_speed; }

        public enum Movers
        {
            CharacterInputMover,
            CarInputMover,
        }

        public void ResetMovable()
        {
            switch (_start_mover)
            {
                case Movers.CharacterInputMover:
                    _movable = new InputCharacterMover();
                    break;
                case Movers.CarInputMover:
                    _movable = new InputCarMover();
                    break;
            }
        }

        public virtual void Initialize()
        {
            if (!Entity.TryGetComponent(out Rigidbody rb))
                throw new System.Exception($"''{Entity.name}'' doesn't has Rigidbody");

            Rigidbody = rb;
            ResetMovable();
        }

        public void ChangeMovable(IMovable new_movable)
        {
            _movable = new_movable;
        }

        private void Update()
        {
            if (_movable == null)
                return;

            _movable.Move(Rigidbody, Max_speed);
        }
    }
}
