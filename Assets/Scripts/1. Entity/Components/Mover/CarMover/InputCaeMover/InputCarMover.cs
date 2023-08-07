using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EntitySystem.Components
{
    public class InputCarMover : Mover, IRotatable
    {
        [SerializeField] private float _rotate_speed = 10;
        private Vector3 current_direction;

        public void FixedUpdate()
        {
            float direction_z = Input.GetAxis("Vertical");
            float direction_x = Input.GetAxis("Horizontal");
            Vector3 direction = Entity.transform.forward * direction_z;
            current_direction = Vector3.Lerp(current_direction, direction, Time.fixedDeltaTime * 10);
            Move(current_direction);

            RotateTo(0, direction_x * Rigidbody.velocity.magnitude, 0);
        }

        public void RotateTo(float rotation_x, float rotation_y, float rotation_z)
        {
            Quaternion delta_rotation = Quaternion.Euler(new Vector3(rotation_x, rotation_y, rotation_z) * Time.deltaTime * _rotate_speed);
            Rigidbody.MoveRotation(Rigidbody.rotation * delta_rotation);
        }

        private void OnDrawGizmos()
        {
            if (!Rigidbody)
                return;

            Gizmos.color = Color.red;
            Gizmos.DrawRay(Rigidbody.transform.position, Rigidbody.velocity);
        }
    }
}
