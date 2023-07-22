using Helpers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace EntitySystem.Components
{

    public class Monologue : EntityComponent
    {
        [SerializeField] private UnityEvent<List<string>> _on_started;
        [SerializeField] private UnityEvent _on_ended;

        public void StartNew(List<string> new_monologue)
        {
            _on_started?.Invoke(new List<string>(new_monologue));
        }

        public void End()
        {
            _on_ended?.Invoke();
        }
    }
}
