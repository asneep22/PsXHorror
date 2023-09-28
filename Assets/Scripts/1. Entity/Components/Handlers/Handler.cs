using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace EntitySystem.Components
{
    public class Handler : EntityComponent, IHandlerable
    {
        [SerializeField] private UnityEvent _on_handled;

        public UnityEvent On_handled { get => _on_handled; }

        public virtual void Handle(Entity from)
        {
            On_handled?.Invoke();
        }
    }
}
