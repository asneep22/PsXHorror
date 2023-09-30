using EntitySystem;
using EntitySystem.Components;
using System.Collections;
using System.Collections.Generic;
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

        if (!entity.Check<PathMover>())
            return;

        StartCoroutine(TrackingVelocity(entity.Get<PathMover>().Rigidbody));
    }

    private IEnumerator TrackingVelocity(Rigidbody rb)
    {
        while (rb.velocity.sqrMagnitude > 1f)
        {
            yield return null;
        }

        print("ended");
        On_movement_ended?.Invoke();
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = _draw_color;
        Gizmos.DrawSphere(transform.position, 3);
    }
}
