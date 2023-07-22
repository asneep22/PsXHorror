using EntitySystem.Components;
using System.Collections.Generic;
using UnityEngine;

namespace EntitySystem.Triggers
{
    public class MonologueTrigger : Trigger
    {
        [SerializeField] private List<string> _monologue;

        public override void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out Entity entity))
                return;

            if (!entity.Check<Monologue>())
                return;

            entity.Get<Monologue>().StartNew(_monologue);
           _on_triggered?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
