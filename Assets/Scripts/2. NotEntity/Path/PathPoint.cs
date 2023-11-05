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

    [SerializeField] private PathPoint _next_path_point;

    public override void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out Entity entity))
            return;

        if (!entity.TryGet(out Mover mover))
            return;

        mover.ChangeMovable(new PathMover(this));

        if (!entity.TryGet(out Rotator rotator))
            return;

        rotator.ChangeRotator(new LookAtRotator(NextPathPoint?.transform, 3));

/*        entity.Get<PathMover>().gameObject.SetActive(true);
        entity.Get<PathMover>().SetPathPoint(this);*/

    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        if (_next_path_point == null)
            return;

        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, NextPathPoint.transform.position);
    }
}