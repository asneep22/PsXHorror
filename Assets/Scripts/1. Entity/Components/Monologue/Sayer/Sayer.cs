using System;
using System.Collections.Generic;
using UnityEngine;

namespace EntitySystem.Components.DialogueSystem
{
    [Serializable]
    public class Sayer
    {
        [SerializeField] private string _text;
        [SerializeField] private float _time = 1.5f;
        [SerializeField] private List<LookAtRotator> _rotators;
        [SerializeField] private Transform _look_target;

        public string Text { get => _text; }
        public float Time { get => _time; }
        public List<LookAtRotator> Rotators { get => _rotators; }
        public Transform Look_target { get => _look_target; }
    }
}
