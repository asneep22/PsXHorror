using Helpers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EntitySystem.Components
{
    public class LookAtRotator : EntityComponent
    {
        [SerializeField] private float _speed = 3;

        private bool _is_enabled;
        private Transform _target;

        public virtual void EnableLookAt(Transform target)
        {
            _is_enabled = true;
            _target = target;
            CoroutineExtension.RepeatUntil(this, () => _is_enabled == true, () => LookAt());
        }

        public void DisableLookAt()
        {
            _is_enabled = false;
        }

        private void LookAt()
        {
            var targetRotation = Quaternion.LookRotation(_target.position - Entity.transform.position);
            Entity.transform.rotation = Quaternion.Slerp(Entity.transform.rotation, targetRotation, _speed * Time.deltaTime);
        }
    }
}


