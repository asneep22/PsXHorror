using EntitySystem.Components;
using EntitySystem.Components.DialogueSystem;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace EntitySystem.Triggers
{
    public class MonologueTrigger : Trigger
    {
        [SerializeField] private List<Sayer> _monologue;
        [SerializeField] private UnityEvent _on_ended;

        public override void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out Entity entity))
                return;

            if (!entity.Check<Monologue>())
                return;

            entity.Get<Monologue>().StartNew(_monologue, _on_ended);
           On_triggered?.Invoke();
           gameObject.SetActive(false);
        }
    }


}
