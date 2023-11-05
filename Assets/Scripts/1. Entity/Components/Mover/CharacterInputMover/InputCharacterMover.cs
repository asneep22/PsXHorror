using UnityEngine;

namespace EntitySystem.Components
{
    public class InputCharacterMover : IMovable
    {
        public void Move(Rigidbody rigidbody, float speed)
        {
            float dir_x = Input.GetAxis("Horizontal");
            float dir_z = Input.GetAxis("Vertical");

            Vector3 dir = rigidbody.transform.forward * dir_z + rigidbody.transform.right * dir_x;
            Vector3 velocity = dir * speed;
            velocity.y = rigidbody.velocity.y;
            rigidbody.velocity = velocity;
        }
    }
}
