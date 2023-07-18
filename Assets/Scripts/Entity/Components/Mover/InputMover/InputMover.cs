using UnityEngine;

public class InputMover : Mover
{
    [SerializeField] private float _speed = 10;

    public void FixedUpdate()
    {
        float direction_x = Input.GetAxis("Horizontal");
        float direction_z = Input.GetAxis("Vertical");
        Vector3 direction = Entity.transform.forward * direction_z + Entity.transform.right * direction_x;
        Move(direction, _speed);
    }
}