using UnityEngine;

namespace EntitySystem.Components
{
    public class InputCarMover : IMovable
    {
        public void Move(Rigidbody movable_rb, float speed)
        {
            float direction_z = Input.GetAxis("Vertical");
            Vector3 dir = movable_rb.transform.forward * direction_z;
            movable_rb.AddForce(dir.normalized * speed);
            movable_rb.velocity = Vector3.ClampMagnitude(movable_rb.velocity, speed);
        }
    }
}
