using System;
using UnityEngine;

namespace EntitySystem.Components.DialogueSystem
{
    [Serializable]
    public class DialogueNode
    {
        [SerializeField] private string _text;
        [SerializeField] private float _time = 1.5f;
        [SerializeField] private Transform _look_target;

        public string Text { get => _text; }
        public float Time { get => _time; }
        public Transform Look_target { get => _look_target; }

    }
}
