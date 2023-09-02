using UnityEngine;

namespace EntitySystem.Components
{
    public class XDirectionRotator : Rotator
    {

        [SerializeField] private float _rotate_speed = 10;
        private Mover _mover;

        public void Start()
        {
            if (!Entity.Check<Mover>())
                return;

            _mover = Entity.Get<Mover>();
        }

        private void FixedUpdate()
        {
            if (!_mover)
                return;

            float direction_x = Input.GetAxis("Horizontal");
            RotateTo(0, direction_x, 0, _mover.Rigidbody.velocity.magnitude);

        }

        public override void RotateTo(float rotation_x, float rotation_y = 0, float rotation_z = 0, float _rotate_speed = 10)
        {
            Quaternion delta_rotation = Quaternion.Euler(new Vector3(rotation_x, rotation_y, rotation_z) * Time.deltaTime * _rotate_speed);
            _mover.Rigidbody.MoveRotation(_mover.Rigidbody.rotation * delta_rotation);
        }
    }
}
