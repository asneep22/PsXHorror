using EntitySystem.Components.DialogueSystem;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace EntitySystem.Components
{

    public class Monologue : EntityComponent
    {
        [SerializeField] private UnityEvent _on_ended;

        public void StartNew(List<DialogueNode> new_monologue, UnityEvent on_texts_ended)
        {
            UIManager.Instance.Dialogue_menu.StartMonologue(new_monologue, on_texts_ended, Entity.Get<Rotator>());
        }
    }
}
