using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EntitySystem.Components
{
    public class InputCarMover : Mover, IRotatable
    {
        [SerializeField] private float _rotate_speed = 10;

        public void FixedUpdate()
        {
            float direction_z = Input.GetAxis("Vertical");
            float direction_x = Input.GetAxis("Horizontal");
            float current_direction_x = 0;
            Vector3 direction = Entity.transform.forward * direction_z;
            current_direction_x = Mathf.Lerp(current_direction_x, direction_x, Time.fixedDeltaTime);
            Move(direction);
            RotateTo(0, current_direction_x * Rigidbody.velocity.magnitude * _rotate_speed, 0);
        }

        public void RotateTo(float rotation_x, float rotation_y, float rotation_z)
        {
            Quaternion delta_rotation = Quaternion.Euler(new Vector3(rotation_x, rotation_y, rotation_z) * Time.fixedDeltaTime);
            Rigidbody.MoveRotation(Rigidbody.rotation * delta_rotation);
        }
    }
}
