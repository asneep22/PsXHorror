using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class Menu : MonoBehaviour
{
    public UnityEvent On_showed;
    public UnityEvent On_hided;

    [SerializeField] private bool _hide_on_start;

    private VisualElement root;

    public bool Is_showed { get; private set; }

    public virtual void Awake()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
    }

    public virtual void Start()
    {
        if (_hide_on_start)
        {
            Hide();
            return;
        }

        Show();

    }

    public virtual void Show()
    {
        Get<VisualElement>("Root").RemoveFromClassList("hidden");
        On_showed?.Invoke();
        Is_showed = true;
    }

    public virtual void Hide()
    {
        Get<VisualElement>("Root").AddToClassList("hidden");
        On_hided?.Invoke();
        Is_showed = false;
    }

    protected VisualElement Get<T>(string name) where T: VisualElement
    {
        return root.Q<T>(name);
    }

}
