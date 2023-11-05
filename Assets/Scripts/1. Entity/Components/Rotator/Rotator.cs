using EntitySystem.Components.Rotators;
using UnityEngine;

namespace EntitySystem.Components
{
    public class Rotator : EntityComponent, IInitializable 
    {
        [SerializeField] private bool _lock_x, _lock_y, _lock_z;
        [SerializeField] private Rotators _start_rotator;
        private Transform _entity_transform;
        private IRotatable _rotatable;

        public enum Rotators
        {
            Null,
            InputMouseRotator
        }

        private void Start()
        {
            ResetRotator();
        }

        public virtual void Initialize()
        {
            _entity_transform = Entity.transform;
        }

        public void Update()
        {
            Rotate(_rotatable);
        }

        public void ResetRotator()
        {
            switch (_start_rotator)
            {
                case Rotators.InputMouseRotator:
                    _rotatable = new InputMouseRotator(SettingsManager.Instance.Mouse_settings.Sens_x, SettingsManager.Instance.Mouse_settings.Sens_y);
                    break;
                default:
                    break;
            }
        }

        private void Rotate(IRotatable rotatable) {
            if (rotatable == null)
                return;

            rotatable.Rotate(_entity_transform);
        } 

        public void ChangeRotator(IRotatable new_rotatable) => _rotatable = new_rotatable;
    }
}
