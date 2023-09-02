using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EntitySystem.Components
{
    public class InputCarMover : Mover
    {
        public void FixedUpdate()
        {
            float direction_z = Input.GetAxis("Vertical");
            Vector3 direction = Entity.transform.forward * direction_z;
            Move(direction);
        }
    }
}
