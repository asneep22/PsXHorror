using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace EntitySystem.Components
{
    public class Handler : EntityComponent, IHandlerable
    {
        public UnityEvent On_handled { get; }

        public virtual void Handle(Entity from)
        {
            On_handled?.Invoke();
        }
    }
}
