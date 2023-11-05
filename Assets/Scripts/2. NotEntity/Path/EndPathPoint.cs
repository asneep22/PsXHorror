using EntitySystem;
using EntitySystem.Components;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class EndPathPoint : PathPoint
{
    [SerializeField] private UnityEvent On_movement_ended;

    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        if (!other.TryGetComponent(out Entity entity))
            return;

        if (!entity.TryGet(out Mover mover))
            return;

        StartCoroutine(TrackingVelocity(mover.Rigidbody));
    }

    private IEnumerator TrackingVelocity(Rigidbody rb)
    {
        while (rb.velocity.sqrMagnitude > 1f)
        {
            yield return null;
        }

        On_movement_ended?.Invoke();
    }
}
