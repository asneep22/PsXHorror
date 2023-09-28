using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace EntitySystem.Components
{
    public class MonologueInteractHandler : InteractHandler
    {
        [SerializeField] private List<string> _monolog_texts = new();
        [SerializeField] private UnityEvent _on_texts_ended;

        public override void Handle(Entity from)
        {
            base.Handle(from);

            if (!from.TryGet(out Monologue monologue))
                return;

            monologue.StartNew(_monolog_texts, _on_texts_ended);
        }


    }
}

