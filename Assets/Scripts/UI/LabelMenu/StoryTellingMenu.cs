using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class StoryTellingMenu : PrintTextMenu
{
    [SerializeField] private string _label_name = "Text_label";

    private Label _text_label;

    public override void Awake()
    {
        base.Awake();
        _text_label = (Label)Get<Label>(_label_name);
    }

    public void Update()
    {
        if (!Is_showed)
            return;

        if (!Input.GetMouseButtonDown(0))
            return;

        if (Print_text_coroutine == null)
            NextText(_text_label);
    }
}
