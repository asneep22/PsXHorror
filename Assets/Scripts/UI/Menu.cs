using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class Menu : MonoBehaviour
{

    [SerializeField] private bool _hide_on_start;
    [SerializeField] private UnityAction _on_showed;
    [SerializeField] private UnityAction _on_hided;

    private VisualElement root;

    public bool IsShowed { get; private set; }

    private void Awake()
    {
        root = GetComponent<UIDocument>().rootVisualElement;

        if (_hide_on_start)
            Get<VisualElement>("Menu").AddToClassList("hidden");
    }

    public virtual void Show()
    {
        Get<VisualElement>("Menu").RemoveFromClassList("hidden");
        _on_showed?.Invoke();
        IsShowed = true;
    }

    public virtual void Hide()
    {
        Get<VisualElement>("Menu").AddToClassList("hidden");
        _on_hided?.Invoke();
        IsShowed = false;
    }

    protected VisualElement Get<T>(string name) where T: VisualElement
    {
        return root.Q<T>(name);
    }

}
