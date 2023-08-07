using EntitySystem.Components;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EntitySystem.Components
{
    public class InputRotator : Rotator
    {
        [SerializeField] private float _rotate_speed = 3;

        private void FixedUpdate()
        {
            float rotate_x_strength = Input.GetAxis("Horizontal") * _rotate_speed;
            float rotate_y_strength = Input.GetAxis("Vertical") * _rotate_speed;


            RotateTo(rotate_y_strength, rotate_x_strength, 0);
        }
    }
}

