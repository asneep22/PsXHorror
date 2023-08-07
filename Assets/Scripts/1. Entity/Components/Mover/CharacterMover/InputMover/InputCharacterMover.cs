using UnityEngine;

namespace EntitySystem.Components
{
    public class InputCharacterMover : Mover
    {
        public void FixedUpdate()
        {
            float direction_x = Input.GetAxis("Horizontal");
            float direction_z = Input.GetAxis("Vertical");
            Vector3 direction = Entity.transform.forward * direction_z + Entity.transform.right * direction_x;
            Move(direction);
        }
    }
}
