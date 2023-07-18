using NaughtyAttributes;
using System.Collections.Generic;
using UnityEngine;
using Entity.Components;

namespace Entity
{
    public class Entity : MonoBehaviour
    {
        private List<EntityComponent> _components = new();
        [SerializeField, Required] private Transform _parentOfComponents;

        private void Reset()
        {
            GameObject parentOfComponents = new GameObject();
            parentOfComponents.transform.SetParent(transform);
            parentOfComponents.name = "Parent of components";
            _parentOfComponents = parentOfComponents.transform;
        }

        private void Awake()
        {
            InitializeComponents();
        }

        #region InitializeComponent

        [Button]
        public void InitializeComponents()
        {
            _components = new(_parentOfComponents.GetComponentsInChildren<EntityComponent>());

            foreach (EntityComponent component in _components)
            {
                component.Entity = this;
                InitializeComponent(component);
            }

        }
        private void InitializeComponent(EntityComponent component)
        {
            if (component.TryGetComponent(out IInitializable initializable))
                initializable.Initialize();
        }

        #endregion

        #region GetComponent

        public T[] GetAll<T>()
        {
            T[] components = _parentOfComponents.GetComponentsInChildren<T>();

            if (components.Length > 0)
                return components;

            throw new System.Exception($"EntityComponent ''{typeof(T)}'' doesn't exist on ''{name}'' object");
        }
        public T Get<T>()
        {
            foreach (EntityComponent component in _components)
                if (component.TryGetComponent(out T tComponent))
                    return tComponent;

            throw new System.Exception($"EntityComponent ''{typeof(T)}'' doesn't exist on ''{name}'' object");
        }

        #endregion

        #region CheckComponent

        public bool Check<T>()
        {
            foreach (var component in _components)
            {
                try
                {
                    if (component.TryGetComponent(out T _))
                        return true;

                }
                catch (System.Exception)
                {
                    throw new System.Exception($"list of components on {name} entity found null components. Remove it");
                }
            }

            return false;
        }

        #endregion

        #region AddComponent

        public T Add<T>() where T : EntityComponent
        {
            if (Check<T>())
                throw new System.Exception($"{typeof(T)} component is current aviable");

            GameObject component = new($"{typeof(T)}");
            T tComponent = component.AddComponent<T>();
            tComponent.transform.SetParent(_parentOfComponents.transform);
            _components.Add(tComponent);
            InitializeComponent(tComponent);
            return tComponent;
        }

        public T Add<T>(Transform parent) where T : EntityComponent
        {
            if (Check<T>())
                throw new System.Exception($"{typeof(T)} component is current aviable");

            GameObject component = new($"{typeof(T)}");
            T tComponent = component.AddComponent<T>();
            tComponent.transform.SetParent(parent);
            _components.Add(tComponent);
            InitializeComponent(tComponent);
            return tComponent;
        }

        #endregion
    }
}