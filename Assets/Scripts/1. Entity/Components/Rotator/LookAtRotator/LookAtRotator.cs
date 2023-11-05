using UnityEngine;

namespace EntitySystem.Components
{
    public class LookAtRotator : IRotatable
    {
        private Transform _target;
        private float _rotate_speed;

        public LookAtRotator(Transform target = null, float rotate_speed = 3)
        {
            _target = target;
            _rotate_speed = rotate_speed;
        }

        public void Initialize()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        public void Rotate(Transform rotatable_obj)
        {
            if (!_target)
                return;
            
            var targetRotation = Quaternion.LookRotation(_target.position - rotatable_obj.position);
            rotatable_obj.rotation = Quaternion.Slerp(rotatable_obj.rotation, targetRotation, _rotate_speed * Time.deltaTime);
        }
    }
}


