using UnityEngine;

namespace EntitySystem.Components
{
    public class Rotator : EntityComponent, IInitializable, IRotatable 
    {
        [SerializeField] private bool _lock_x, _lock_y, _lock_z;
        private Transform _entity_transform;

        public void Initialize()
        {
            _entity_transform = Entity.transform;
        }

        public virtual void RotateTo(float rotation_x, float rotation_y = 0, float rotation_z = 0)
        {
            if (_lock_x)
                rotation_x = 0;
            if (_lock_y)
                rotation_y = 0;
            if (_lock_z)
                rotation_z = 0;

            _entity_transform.rotation = Quaternion.Euler(rotation_x, rotation_y, rotation_z);
        }
    }
}
