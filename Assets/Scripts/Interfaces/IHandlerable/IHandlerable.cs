using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace EntitySystem.Components
{
    public interface IHandlerable
    {
        public UnityEvent On_handled { get; }
        public void Handle(Entity from);
    }
}
