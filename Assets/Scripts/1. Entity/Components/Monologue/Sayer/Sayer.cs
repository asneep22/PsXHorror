using System;
using System.Collections.Generic;
using UnityEngine;

namespace EntitySystem.Components.DialogueSystem
{
    [Serializable]
    public class Sayer
    {
        [SerializeField] private string _text;
        [SerializeField] private List<LookAtRotator> _rotators;
        [SerializeField] private Transform _look_target;

        public string Text { get => _text; }
        public List<LookAtRotator> Rotators { get => _rotators; }
        public Transform Look_target { get => _look_target; }

        public void DisableLookAtAll()
        {
            foreach (LookAtRotator rotator in _rotators)
                rotator.DisableLookAt();
        }
    }
}
