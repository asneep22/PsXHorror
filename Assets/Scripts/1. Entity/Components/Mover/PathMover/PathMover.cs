using UnityEngine;

namespace EntitySystem.Components
{
    public class PathMover : IMovable
    {
        private PathPoint _current_point;
        public PathPoint Current_point
        {
            get
            {
                return _current_point;
            }
            set
            {
                if (value != null) _current_point = value;
            }
        }

        public PathMover(PathPoint currentPoint) => Current_point = currentPoint;

        public void Move(Rigidbody movable_rb, float speed)
        {
            if (_current_point is EndPathPoint)
            {
                /*movable_rb.GetComponent<Entity>().Get<Mover>().ResetMovable();*/
                return;
            }

            Vector3 dir = (_current_point.NextPathPoint.transform.position - _current_point.transform.position).normalized;
            movable_rb.velocity = dir * speed;
        }
    }
}
