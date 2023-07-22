using UnityEngine;
using UnityEngine.Events;

namespace EntitySystem.Components
{
    public class InteractHandler : Handler, IInteractable
    {
        public override void Handle(Entity from)
        {
            base.Handle(from);
            print("interact");
        }
    }
}
