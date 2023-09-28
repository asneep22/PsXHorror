using EntitySystem;
using EntitySystem.Components;
using EntitySystem.Triggers;
using UnityEngine;

public class PathPoint : Trigger
{
    public PathPoint NextPathPoint
    {
        get {
            return _next_path_point;
        }
        set
        {
            if (value != null)
                _next_path_point = value;
        }
    }

    [SerializeField] public Color _draw_color = Color.yellow;

    [SerializeField] private PathPoint _next_path_point;

    public override void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out Entity entity))
            return;

        if (!entity.Check<PathMover>())
            return;

        if (entity.Check<RigidbodyGravityMover>())
            entity.Get<RigidbodyGravityMover>().gameObject.SetActive(false);

        if (_next_path_point != null)
            entity.transform.LookAt(_next_path_point.transform);

        entity.Get<PathMover>().gameObject.SetActive(true);
        entity.Get<PathMover>().SetPathPoint(this);

    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = _draw_color;
        Gizmos.DrawSphere(transform.position, 3);

        if (_next_path_point == null)
            return;

        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, NextPathPoint.transform.position);
    }
}