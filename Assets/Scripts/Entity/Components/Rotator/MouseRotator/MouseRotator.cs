using UnityEngine;

namespace EntitySystem.Components
{

    public class MouseRotator : Rotator
    {
        [SerializeField] private float _sens_x = 15;
        [SerializeField] private float _sens_y = 15;

        private float _rotation_x;
        private float _rotation_y;


        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        public void Update()
        {
            float mouse_x = Input.GetAxisRaw("Mouse X") * Time.deltaTime * _sens_x;
            float mouse_y = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * _sens_y;

            _rotation_y += mouse_x;
            _rotation_x -= mouse_y;

            _rotation_x = Mathf.Clamp(_rotation_x, -90f, 90f);

            RotateTo(_rotation_x, _rotation_y);
        }
    }
}
