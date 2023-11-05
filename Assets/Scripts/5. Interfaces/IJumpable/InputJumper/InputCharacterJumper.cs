using UnityEngine;

namespace EntitySystem.Components
{
    public class InputCharacterJumper : IJumpable
    {
        public void Jump(Rigidbody jumpable_rb, float strength)
        {
            if (Input.GetKeyDown(KeyCode.Space))
                jumpable_rb.AddForce(Vector3.up * strength, ForceMode.Impulse);
        }
    }
}

