using Helpers;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class Menu : MonoBehaviour
{
    public UnityEvent On_showed;
    public UnityEvent On_hided;

    [SerializeField] private bool _hide_on_start;
    [SerializeField] private float _hide_speed = 1;

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
            StartHide();
            return;
        }

        StartShow();

    }

    public virtual void StartShow()
    {
        VisualElement visual_element = Get<VisualElement>("Root");
        visual_element.RemoveFromClassList("pop-fade");

        On_showed?.Invoke();
        Is_showed = true;
    }

    public virtual void StartHide()
    {
        VisualElement visual_element = Get<VisualElement>("Root");
        visual_element.AddToClassList("pop-fade");
        On_hided?.Invoke();
        Is_showed = false;
    }

    protected VisualElement Get<T>(string name) where T: VisualElement
    {
        return root.Q<T>(name);
    }

}
