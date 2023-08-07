using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EntitySystem.Components
{
    public class PathMover : Mover
    {
        private Vector3 _current_direction;

        public void FixedUpdate()
        {
            Move(_current_direction.normalized);
        }

        public virtual void SetPathPoint(PathPoint path_point)
        {
            _current_direction = path_point.NextPathPoint == null ? Vector3.zero : path_point.NextPathPoint.transform.position - path_point.transform.position;
        }
    }
}
