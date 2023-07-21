using UnityEngine;

namespace EntitySystem.Components
{
    public class Rotator : EntityComponent, IInitializable, IRotator
    {
        private Transform _entity_transform;

        public void Initialize()
        {
            _entity_transform = Entity.transform;
        }

        public virtual void RotateTo(float rotation_x, float rotation_y)
        {
            _entity_transform.rotation = Quaternion.Euler(rotation_x, rotation_y, 0);
        }
    }
}
