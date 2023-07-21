using UnityEngine;
using UnityEngine.Events;

namespace EntitySystem.Triggers
{
    public class Trigger : MonoBehaviour
    {
        [SerializeField] protected UnityEvent _on_triggered;

        public virtual void OnTriggerEnter(Collider other)
        {

        }

        public virtual void OnCollisionEnter(Collision collision)
        {
            
        }
    }
}
