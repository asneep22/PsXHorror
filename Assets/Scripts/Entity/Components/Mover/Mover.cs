using Entity.Components;
using UnityEngine;

public class Mover : EntityComponent, IInitializable, IMovable
{
    [SerializeField] private float _speed_fade_off_strength = 10f;
    private Rigidbody _rigidbody;

    public void Initialize()
    {
        if (Entity.TryGetComponent(out Rigidbody rb))
        {
            _rigidbody = rb;
            return;
        }

        throw new System.Exception($"''{Entity.name}'' doesn't has Rigidbody");
    }

    public virtual void Move(Vector3 new_direction, float speed)
    {
        Vector3 lerped_velocity = Vector3.Lerp(_rigidbody.velocity, new_direction, Time.fixedDeltaTime * _speed_fade_off_strength);
        _rigidbody.velocity = lerped_velocity.normalized * speed;
    }
}
