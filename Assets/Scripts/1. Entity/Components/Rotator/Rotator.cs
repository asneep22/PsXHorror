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
            Vector3 new_rotation = UpdateLockedRotation(rotation_x, rotation_y, rotation_z);
            _entity_transform.localRotation = Quaternion.Euler(new_rotation.x, new_rotation.y, new_rotation.z);
        }

        public virtual void RotateTo(float rotation_x, float rotation_y = 0, float rotation_z = 0, float _rotate_speed = 10)
        {
            Vector3 new_rotation = UpdateLockedRotation(rotation_x, rotation_y, rotation_z);
            _entity_transform.localRotation = Quaternion.Euler(new_rotation.x, new_rotation.y * _rotate_speed, new_rotation.z);
        }

        public virtual void AddRotate(float rotation_x, float rotation_y = 0, float rotation_z = 0)
        {
            Vector3 new_rotation = UpdateLockedRotation(rotation_x, rotation_y, rotation_z);
            _entity_transform.Rotate(new_rotation.x, new_rotation.y, new_rotation.z);
        }

        private Vector3 UpdateLockedRotation(float rotation_x, float rotation_y = 0, float rotation_z = 0)
        {
            if (_lock_x)
                rotation_x = 0;
            if (_lock_y)
                rotation_y = 0;
            if (_lock_z)
                rotation_z = 0;

            return new Vector3(rotation_x, rotation_y, rotation_z);
        }

    }
}
