using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EntitySystem.Components
{
    public class InputCarMover : RigidbodyGravityMover
    {
        public void FixedUpdate()
        {
            float direction_z = Input.GetAxis("Vertical");
            Vector3 direction = Entity.transform.forward * direction_z;
            Movement_direction = Entity.transform.forward;
            Move(direction, Speed);
        }
    }
}
