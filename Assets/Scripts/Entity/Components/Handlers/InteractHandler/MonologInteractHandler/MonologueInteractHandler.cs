using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EntitySystem.Components
{
    public class MonologueInteractHandler : InteractHandler
    {
        [SerializeField] private List<string> _monolog_texts = new();

        public override void Handle(Entity from)
        {
            base.Handle(from);

            if (!from.Check<Monologue>())
                return;

            from.Get<Monologue>().StartNew(_monolog_texts);
        }


    }
}

