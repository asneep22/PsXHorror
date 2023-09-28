using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EntitySystem.Components
{
    public class PathMover : RigidbodyGravityMover
    {
        private Vector3 _current_direction;

        public void FixedUpdate()
        {
            if (_current_direction != Vector3.zero)
                Move(_current_direction.normalized, Speed);
        }

        public virtual void SetPathPoint(PathPoint path_point)
        {
            if (path_point.NextPathPoint == null)
            {
                _current_direction = Vector3.zero;
                return;
            }
            
            Vector3 new_direction = path_point.NextPathPoint.transform.position - path_point.transform.position;
            _current_direction = new_direction;
        }
    }
}
