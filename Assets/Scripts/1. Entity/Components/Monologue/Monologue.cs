using Helpers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace EntitySystem.Components
{

    public class Monologue : EntityComponent
    {
        [SerializeField] private UnityEvent<List<string>, UnityEvent> _on_started;
        [SerializeField] private UnityEvent<List<string>> _on_ended;

        public void StartNew(List<string> new_monologue, UnityEvent on_texts_ended)
        {
            _on_started?.Invoke(new List<string>(new_monologue), on_texts_ended);
        }
    }
}
