using UnityEngine;

namespace EntitySystem.Components.Rotators
{
    public class InputMouseRotator: IRotatable
    {
        private readonly float _sens_x;
        private readonly float _sens_y;
        private float _rotation_x;
        private float _rotation_y;

        public InputMouseRotator(float sens_x, float sens_y)
        {
            _sens_x = sens_x;
            _sens_y = sens_y;
            Initialize();
        }

        public void Rotate(Transform rotatable_obj)
        {
            float mouse_x = Input.GetAxisRaw("Mouse X") * Time.deltaTime * _sens_x;
            float mouse_y = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * _sens_y;

            if (mouse_x == 0 && mouse_y == 0)
                return;

            _rotation_y = rotatable_obj.localEulerAngles.y + mouse_x;
            _rotation_x = rotatable_obj.localEulerAngles.x - mouse_y;

            rotatable_obj.localEulerAngles = new Vector3(_rotation_x, _rotation_y, 0);
        }

        public void Initialize()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
