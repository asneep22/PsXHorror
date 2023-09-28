using UnityEngine;
using UnityEngine.Events;

namespace EntitySystem.Triggers
{
    [RequireComponent(typeof(BoxCollider))]
    public class Trigger : MonoBehaviour
    {
        private BoxCollider _box_collider;
        [SerializeField] private Color _color = new(0.46f, 1, 0.2971698f, .25f);
        [SerializeField] protected UnityEvent On_triggered;

        public void Reset()
        {
            _box_collider = GetComponent<BoxCollider>();
            _box_collider.isTrigger = true;
            _box_collider.size = new Vector3(10, 10, 10);
        }

        public virtual void OnTriggerEnter(Collider other)
        {

        }

        public virtual void OnCollisionEnter(Collision collision)
        {
            
        }


        public virtual void OnDrawGizmos()
        {
            if (_box_collider == null)
                _box_collider = GetComponent<BoxCollider>();

            Gizmos.color = _color;
            Gizmos.DrawCube(transform.position, _box_collider.size);
        }
    }
}
