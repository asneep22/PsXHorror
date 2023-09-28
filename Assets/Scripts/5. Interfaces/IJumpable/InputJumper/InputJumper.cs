using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EntitySystem.Components
{
    public class InputJumper : Jumper
    {
        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                Jump();
        }

    }
}

