using UnityEngine;

namespace EntitySystem.Components
{

    public class MouseRotator : Rotator
    {
        private float _sens_x;
        private float _sens_y;
        private float _rotation_x;
        private float _rotation_y;
        private float _last_rotation_x;
        private float _last_rotation_y;


        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            _sens_x = SettingsManager.Instance.Mouse_settings.Sens_x;
            _sens_y = SettingsManager.Instance.Mouse_settings.Sens_y;
        }

        public void Update()
        {
            float mouse_x = Input.GetAxisRaw("Mouse X") * Time.deltaTime * _sens_x;
            float mouse_y = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * _sens_y;


            if (mouse_x == 0 && mouse_y == 0)
                return;

            _rotation_y += mouse_x;
            _rotation_x -= mouse_y;

            _rotation_x = Mathf.Clamp(_rotation_x, -90f, 90f);

            RotateTo(_rotation_x, _rotation_y, 0);
        }
    }
}