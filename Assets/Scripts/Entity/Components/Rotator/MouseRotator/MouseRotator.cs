using UnityEngine;

namespace EntitySystem.Components
{

    public class MouseRotator : Rotator
    {

        [SerializeField] private Transform _rotatable_camera;
        [SerializeField] private float sens_x;
        [SerializeField] private float sens_y;

        private float rotation_x;
        private float rotation_y;

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        public void Update()
        {
            float mouse_x = Input.GetAxisRaw("Mouse X") * Time.fixedDeltaTime * sens_x;
            float mouse_y = Input.GetAxisRaw("Mouse Y") * Time.fixedDeltaTime * sens_y;

            rotation_y += mouse_x;
            rotation_x -= mouse_y;

            rotation_x = Mathf.Clamp(rotation_x, -90f, 90f);

            RotateTo(rotation_x, rotation_y);
        }

        public override void RotateTo(float rotation_x, float rotation_y)
        {
            _rotatable_camera.rotation = Quaternion.Euler(rotation_x, rotation_y, 0);
            base.RotateTo(0, rotation_y);
        }
    }
}
