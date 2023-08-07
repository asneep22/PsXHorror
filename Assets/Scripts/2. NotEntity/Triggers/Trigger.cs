using UnityEngine;
using UnityEngine.Events;

namespace EntitySystem.Triggers
{
    [RequireComponent(typeof(BoxCollider))]
    public class Trigger : MonoBehaviour
    {
        [SerializeField] protected UnityEvent _on_triggered;

        public void Reset()
        {
            GetComponent<BoxCollider>().isTrigger = true;
            GetComponent<BoxCollider>().size = new Vector3(10, 10, 10);
        }

        public virtual void OnTriggerEnter(Collider other)
        {

        }

        public virtual void OnCollisionEnter(Collision collision)
        {
            
        }
    }
}
