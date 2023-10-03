using Helpers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EntitySystem.Components
{
    public class LookAtRotator : EntityComponent
    {
        [SerializeField] private float _speed = 3;

 
        private Transform _target;

        public virtual void BeginLookAt(Transform target, float time)
        {
            _target = target;
            CoroutineExtension.RepeatFixedTime(this, time, () => LookAt());
        }

        private void LookAt()
        {
            var targetRotation = Quaternion.LookRotation(_target.position - Entity.transform.position);
            Entity.transform.rotation = Quaternion.Slerp(Entity.transform.rotation, targetRotation, _speed * Time.deltaTime);
        }
    }
}


