using UnityEngine;

namespace Entity.Components
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

        private void Reset()
        {
            transform.name = GetType().Name;
        }
    }
}