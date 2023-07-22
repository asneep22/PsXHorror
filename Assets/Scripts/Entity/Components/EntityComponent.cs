using UnityEngine;

namespace EntitySystem.Components
{
    public class EntityComponent : MonoBehaviour
    {
        private Entity _entity;

        public Entity Entity
        {
            get
            {
                return _entity = _entity ??= transform.root.GetComponent<Entity>();
            }
            set
            {
                _entity ??= value;
            }
        }

        public virtual void Reset()
        {
            transform.name = GetType().Name;
        }
    }
}