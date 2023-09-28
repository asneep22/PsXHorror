using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EntitySystem.Components
{
    public class RigidbodyFaller : EntityComponent, IInitializable
    {
        private GroundChecker _ground_checker;
        private float _y_velocity;

        public float Y_velocity { get => _y_velocity; }

        public virtual void Initialize()
        {
            if (!Entity.TryGet(out GroundChecker ground_checker))
            {
                Destroy(gameObject);
                throw new System.Exception($" add to ''{Entity.name}'' ground cheker. Mover was deleted");
            }

            _ground_checker = ground_checker;
        }

        public void Fall()
        {
            if (!_ground_checker.IsOnGround)
                _y_velocity += Physics.gravity.y * Time.fixedDeltaTime;
            else
                _y_velocity = 0;
        }

        public void SetYVelocity(float new_y_velocity)
        {
            _y_velocity = new_y_velocity;
        }
    }

}

